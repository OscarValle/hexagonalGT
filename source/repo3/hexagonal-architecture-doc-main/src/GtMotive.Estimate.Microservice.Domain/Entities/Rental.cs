using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rental"/> class.
    /// </summary>
    /// <param name="vehicleId">The unique identifier of the rented vehicle.</param>
    /// <param name="customerId">The unique identifier of the customer who rented the vehicle.</param>
    /// <param name="startDate">The start date of the rental period.</param>
    /// <param name="endDate">The end date of the rental period.</param>
    /// <param name="realEndDate">The real end date of the rental period (real return date).</param>
    public class Rental(Guid vehicleId, string customerId, DateTime? startDate, DateTime? endDate, DateTime? realEndDate = null)
    {
        /// <summary>
        /// Gets the unique identifier of the rental.
        /// </summary>
        public Guid Id { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// Gets the unique identifier of the rented vehicle.
        /// </summary>
        public Guid VehicleId { get; private set; } = vehicleId;

        /// <summary>
        /// Gets the unique identifier of the customer who rented the vehicle.
        /// </summary>
        public string CustomerId { get; private set; } = customerId;

        /// <summary>
        /// Gets the start date of the rental period.
        /// </summary>
        public DateTime? StartDate { get; private set; } = startDate;

        /// <summary>
        /// Gets the end date of the rental period. Null if the rental is still active.
        /// </summary>
        public DateTime? EndDate { get; private set; } = endDate;

        /// <summary>
        /// Gets the actual end date (return date) of the vehicle. Null if the rental is currently active.
        /// </summary>
        public DateTime? RealEndDate { get; private set; } = realEndDate;

        /// <summary>
        /// Checks if the rental is active relative to a specific reference date.
        /// </summary>
        /// <param name="referenceDate">The date considered "today" for evaluation.</param>
        /// <returns>Is Currently Active.</returns>
        public bool IsCurrentlyActive(DateTime referenceDate)
        {
            return RealEndDate == null && referenceDate.Date >= StartDate.Value.Date && referenceDate.Date < EndDate.Value.Date;
        }

        /// <summary>
        /// Marks the rental as completed by setting the RealEndDate.
        /// </summary>
        /// <param name="actualReturnDate">The date of real return.</param>
        public void EndRental(DateTime actualReturnDate)
        {
            if (RealEndDate.HasValue)
            {
                throw new InvalidOperationException("This rental has already been returned.");
            }

            RealEndDate = actualReturnDate.Date;
        }
    }
}
