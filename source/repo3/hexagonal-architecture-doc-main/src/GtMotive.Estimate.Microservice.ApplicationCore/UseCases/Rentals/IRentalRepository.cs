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
        /// Get all Customer Rentals.
        /// </summary>
        /// <param name="customerId">Customer Id.</param>
        /// <param name="isActive">Is Active.</param>
        /// <param name="referenceDate">Date of reference for the rental, todays date generally.</param>
        /// <returns>IEnumerable of all Available Rentals.</returns>
        Task<IEnumerable<Rental>> GetByCustomerIdAsync(string customerId, bool? isActive, DateTime referenceDate);

        /// <summary>
        /// Get a Rental by Id.
        /// </summary>
        /// <param name="id">Rental Id.</param>
        /// <returns>A Rental.</returns>
        Task<Rental> GetByIdAsync(Guid id);
    }
}
