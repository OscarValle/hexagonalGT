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
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task AddAsync(Vehicle vehicle);
    }
}
