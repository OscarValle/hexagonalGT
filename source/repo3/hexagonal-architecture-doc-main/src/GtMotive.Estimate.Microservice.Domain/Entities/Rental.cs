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
    public class Rental(Guid vehicleId, string customerId, DateTime? startDate, DateTime? endDate)
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
        /// Gets a value indicating whether the rental is currently active.
        /// </summary>
        public bool IsActive => EndDate == null;
    }
}
