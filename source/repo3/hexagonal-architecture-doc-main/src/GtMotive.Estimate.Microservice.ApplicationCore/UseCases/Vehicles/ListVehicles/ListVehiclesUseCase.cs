using System;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListVehicles
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListVehiclesUseCase"/> class.
    /// </summary>
    /// <param name="vehicleRepository">VehicleRepository.</param>
    /// <param name="outputPort">ListVehiclesOutputPort.</param>
    public sealed class ListVehiclesUseCase(IVehicleRepository vehicleRepository, IListVehiclesOutputPort outputPort) : IListVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IListVehiclesOutputPort _outputPort = outputPort;

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">ListVehiclesInput.</param>
        /// <returns>Response.</returns>
        public async Task Execute(ListVehiclesInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var vehicles = await _vehicleRepository.GetAvailableAsync(input.IsAvailable);
            var output = new ListVehiclesOutput(vehicles);
            _outputPort.StandardHandle(output);
        }
    }
}
