using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterRentalOutput"/> class.
    /// </summary>
    /// <param name="vehicleId">Vehicle Id.</param>
    /// <param name="customerId">Customer Id.</param>
    /// <param name="message">Message.</param>
    public class RegisterRentalOutput(Guid vehicleId, string customerId, string message)
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
        /// Gets the system message.
        /// </summary>
        public string Message { get; } = message;
    }
}
