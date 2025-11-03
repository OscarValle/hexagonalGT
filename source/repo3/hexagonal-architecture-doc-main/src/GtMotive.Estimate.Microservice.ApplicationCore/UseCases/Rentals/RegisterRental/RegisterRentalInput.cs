using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterRentalInput"/> class.
    /// </summary>
    /// <param name="vehicleId">The unique identifier of the rented vehicle.</param>
    /// <param name="customerId">The unique identifier of the customer who rented the vehicle.</param>
    /// <param name="startDate">The start date of the rental period.</param>
    /// <param name="endDate">The end date of the rental period.</param>
    public class RegisterRentalInput(Guid vehicleId, string customerId, DateTime? startDate, DateTime? endDate) : IUseCaseInput
    {
        /// <summary>
        /// Gets the unique identifier of the rented vehicle.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the unique identifier of the customer who rented the vehicle.
        /// </summary>
        public string CustomerId { get; } = customerId;

        /// <summary>
        /// Gets the start date of the rental period.
        /// </summary>
        public DateTime? StartDate { get; } = startDate;

        /// <summary>
        /// Gets the end date of the rental period.
        /// </summary>
        public DateTime? EndDate { get; } = endDate;
    }
}
