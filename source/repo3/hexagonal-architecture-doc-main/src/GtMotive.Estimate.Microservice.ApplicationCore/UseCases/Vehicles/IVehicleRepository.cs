using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// Intercafe to VehicleRepository.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Add Vehicle.
        /// </summary>
        /// <param name="vehicle">Vehicle.</param>
        /// <returns>Add a Vehicle.</returns>
        Task AddAsync(Vehicle vehicle);

        /// <summary>
        /// Get a Vehicle by Id.
        /// </summary>
        /// <param name="id">Vehicle Id.</param>
        /// <returns>A Vehicle.</returns>
        Task<Vehicle> GetByIdAsync(Guid id);

        /// <summary>
        /// Get a Vehicle by License Plate.
        /// </summary>
        /// <param name="licensePlate">License plate.</param>
        /// <returns>A Vehicle.</returns>
        Task<Vehicle> GetByPlateAsync(string licensePlate);

        /// <summary>
        /// Get all Vehicles, excluding some.
        /// </summary>
        /// <param name="excludedVehicleIds">List of Ids for excluded.</param>
        /// <returns>IEnumerable of all Vehicles.</returns>
        Task<IEnumerable<Vehicle>> GetAllExcludingIdsAsync(IEnumerable<Guid> excludedVehicleIds);
    }
}
