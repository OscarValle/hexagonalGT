using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterVehicleUseCase"/> class.
    /// </summary>
    /// <param name="vehicleRepository">VehicleRepository.</param>
    /// <param name="outputPort">OutputPort.</param>
    public class RegisterVehicleUseCase(IVehicleRepository vehicleRepository, IRegisterVehicleOutputPort outputPort) : IRegisterVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly IRegisterVehicleOutputPort _outputPort = outputPort;

        /// <summary>
        /// Execute.
        /// </summary>
        /// <param name="input">RegisterVehicleInput.</param>
        /// <returns>Response.</returns>
        public async Task Execute(RegisterVehicleInput input)
        {
            if (input == null)
            {
                _outputPort.InvalidVehicle("Insufficient data");
                return;
            }

            if (!input.ManufacturingDate.HasValue)
            {
                _outputPort.InvalidVehicle("Manufacturing date is required");
                return;
            }

            if ((DateTime.UtcNow - input.ManufacturingDate.Value).TotalDays > 365 * 5)
            {
                _outputPort.VehicleTooOld("Vehicle is older than 5 years.");
                return;
            }

            var vehicle = new Vehicle(input.LicensePlate, input.Brand, input.Model, input.ManufacturingDate);
            await _vehicleRepository.AddAsync(vehicle);

            _outputPort.Ok(new RegisterVehicleOutput(input.LicensePlate, "Vehicle registered successfully."));
        }
    }
}
