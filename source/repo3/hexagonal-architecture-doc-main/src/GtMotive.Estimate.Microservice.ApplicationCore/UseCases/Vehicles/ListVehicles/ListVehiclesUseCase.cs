using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListVehicles
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListVehiclesUseCase"/> class.
    /// </summary>
    /// <param name="vehicleRepository">VehicleRepository.</param>
    /// <param name="outputPort">ListVehiclesOutputPort.</param>
    /// <param name="rentalRepository">RentalRepository.</param>
    public sealed class ListVehiclesUseCase(IVehicleRepository vehicleRepository, IListVehiclesOutputPort outputPort, IRentalRepository rentalRepository) : IListVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IListVehiclesOutputPort _outputPort = outputPort;

        private readonly IRentalRepository _rentalRepository = rentalRepository;

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">ListVehiclesInput.</param>
        /// <returns>Response.</returns>
        public async Task Execute(ListVehiclesInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var reservedVehicleIds = await _rentalRepository.GetReservedVehicleIdsAsync(input.StartDate, input.EndDate);
            var availableVehicles = await _vehicleRepository.GetAllExcludingIdsAsync(reservedVehicleIds);

            var output = new ListVehiclesOutput(availableVehicles);
            _outputPort.StandardHandle(output);
        }
    }
}
