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
        /// Get all Available Vehicles.
        /// </summary>
        /// <param name="isAvailable">Is Available.</param>
        /// <returns>IEnumerable of all Available Vehicles.</returns>
        Task<IEnumerable<Vehicle>> GetAvailableAsync(bool? isAvailable);

        /// <summary>
        /// Get a Vehicle by Id.
        /// </summary>
        /// <param name="id">Vehicle Id.</param>
        /// <returns>A Vehicle.</returns>
        Task<Vehicle> GetByIdAsync(Guid id);
    }
}
