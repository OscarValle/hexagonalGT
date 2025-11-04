using System;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterRentalUseCase"/> class.
    /// </summary>
    /// <param name="rentalRepository">RentalRepository.</param>
    /// <param name="outputPort">OutputPort.</param>
    /// <param name="dateTimeProvider">DateTimeProvider.</param>
    /// <param name="vehicleRepository">VehicleRepository.</param>
    public class RegisterRentalUseCase(IRentalRepository rentalRepository, IRegisterRentalOutputPort outputPort, IVehicleRepository vehicleRepository, IDateTimeProvider dateTimeProvider) : IRegisterRentalUseCase
    {
        private readonly IRentalRepository _rentalRepository = rentalRepository;
        private readonly IRegisterRentalOutputPort _outputPort = outputPort;

        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">RegisterRentalInput.</param>
        /// <returns>Response.</returns>
        public async Task Execute(RegisterRentalInput input)
        {
            if (input == null)
            {
                _outputPort.InvalidRental("Insufficient data");
                return;
            }

            // Input Validation
            var todayNow = _dateTimeProvider.Now;

            var validationErrors = ValidateInput(input, todayNow);

            if (!string.IsNullOrEmpty(validationErrors))
            {
                _outputPort.InvalidRental(validationErrors);
                return;
            }

            // Vehicle Exist
            var vehicle = await _vehicleRepository.GetByIdAsync(input.VehicleId);

            if (vehicle == null)
            {
                _outputPort.InvalidRental("Vehicle not found");
                return;
            }

            var startDate = input.StartDate.Value;
            var endDate = input.EndDate.Value;

            // No more than one active rental
            var activeRentalsByCustomer = await _rentalRepository.GetOverlappingRentalsAByCustomerAsync(input.CustomerId, startDate, endDate);

            if (activeRentalsByCustomer.Any())
            {
                _outputPort.PersonNotMoreThanOneATime("Person cannot reserve more than one vehicle at a time (in the same period).");
                return;
            }

            // Vehicle is not available in all this period (overlapping)
            var overlappingRentals = await _rentalRepository.GetOverlappingRentalsAByVehicleAsync(input.VehicleId, startDate, endDate);

            if (overlappingRentals.Any())
            {
                _outputPort.InvalidRental("Vehicle is not available for the requested date range.");
                return;
            }

            // Creation
            var rental = new Rental(input.VehicleId, input.CustomerId, startDate, endDate);
            await _rentalRepository.AddAsync(rental);

            _outputPort.Ok(new RegisterRentalOutput(rental.Id, input.VehicleId, input.CustomerId, "Rental registered successfully."));
        }

        /// <summary>
        /// ValidateInput.
        /// </summary>
        /// <param name="input">RegisterRentalInput.</param>
        /// <param name="referenceDate">ReferenceDate.</param>
        /// <returns>Validation text.</returns>
        private static string ValidateInput(RegisterRentalInput input, DateTime referenceDate)
        {
            if (!input.StartDate.HasValue || !input.EndDate.HasValue)
            {
                return "Start date and end date are required for a scheduled rental.";
            }

            if (input.StartDate.Value < referenceDate)
            {
                return "Start date cannot be in the past.";
            }

#pragma warning disable IDE0046 // Convertir a expresión condicional
            if (input.EndDate.Value <= input.StartDate.Value)
            {
                return "End date must be after the start date.";
            }
#pragma warning restore IDE0046 // Convertir a expresión condicional

            return string.Empty;
        }
    }
}
