using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterRentalUseCase"/> class.
    /// </summary>
    /// <param name="rentalRepository">RentalRepository.</param>
    /// <param name="outputPort">OutputPort.</param>
    public class RegisterRentalUseCase(IRentalRepository rentalRepository, IRegisterRentalOutputPort outputPort) : IRegisterRentalUseCase
    {
        private readonly IRentalRepository _rentalRepository = rentalRepository;
        private readonly IRegisterRentalOutputPort _outputPort = outputPort;

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

            if (!input.StartDate.HasValue)
            {
                _outputPort.InvalidRental("Start date is required");
                return;
            }

            if (string.IsNullOrEmpty(input.CustomerId))
            {
                _outputPort.PersonNotMoreThanOneATime("Person not be able to reserve more than one vehicle at a time.");
                return;
            }

            var rental = new Rental(input.VehicleId, input.CustomerId, input.StartDate, input.EndDate);
            await _rentalRepository.AddAsync(rental);

            _outputPort.Ok(new RegisterRentalOutput(input.VehicleId, input.CustomerId, "Rental registered successfully."));
        }
    }
}
