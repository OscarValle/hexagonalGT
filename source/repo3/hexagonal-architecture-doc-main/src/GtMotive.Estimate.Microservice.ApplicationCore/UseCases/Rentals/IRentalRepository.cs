using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// Intercafe to RentalRepository.
    /// </summary>
    public interface IRentalRepository
    {
        /// <summary>
        /// Add Rental.
        /// </summary>
        /// <param name="rental">Rental.</param>
        /// <returns>Task.</returns>
        Task AddAsync(Rental rental);

        /// <summary>
        /// Ends or updates an existing rental.
        /// </summary>
        /// <param name="rental">Rental updated with return details.</param>
        /// <returns>Task.</returns>
        Task UpdateAsync(Rental rental);

        /// <summary>
        /// Get all Customer Rentals between dates.
        /// </summary>
        /// <param name="customerId">Customer Id.</param>
        /// <param name="proposedStartDate">ProposedStartDate.</param>
        /// <param name="proposedEndDate">ProposedEndDate.</param>
        /// <returns>IEnumerable of all Available Rentals.</returns>
        Task<IEnumerable<Rental>> GetOverlappingRentalsAByCustomerAsync(string customerId, DateTime proposedStartDate, DateTime proposedEndDate);

        /// <summary>
        /// Get all Vehicles Rentals between dates.
        /// </summary>
        /// <param name="vehicleId">Vehicle Id.</param>
        /// <param name="proposedStartDate">ProposedStartDate.</param>
        /// <param name="proposedEndDate">ProposedEndDate.</param>
        /// <returns>IEnumerable of Reserved Vehicle Ids.</returns>
        Task<IEnumerable<Rental>> GetOverlappingRentalsAByVehicleAsync(Guid vehicleId, DateTime proposedStartDate, DateTime proposedEndDate);

        /// <summary>
        /// Get all Reserved Vehicle Ids between dates.
        /// </summary>
        /// <param name="startDate">StartDate.</param>
        /// <param name="endDate">EndDate.</param>
        /// <returns>IEnumerable of Reserved Vehicle Ids.</returns>
        Task<IEnumerable<Guid>> GetReservedVehicleIdsAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Get a Rental by Id.
        /// </summary>
        /// <param name="id">Rental Id.</param>
        /// <returns>A Rental.</returns>
        Task<Rental> GetByIdAsync(Guid id);
    }
}
