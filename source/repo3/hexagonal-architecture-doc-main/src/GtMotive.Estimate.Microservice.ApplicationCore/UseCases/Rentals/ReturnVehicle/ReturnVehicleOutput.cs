using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReturnVehicleOutput"/> class.
    /// </summary>
    /// <param name="rentalId">The unique identifier of the rental.</param>
    /// <param name="realEndDate">The end date of the rental  (return date).</param>
    /// <param name="message">Message.</param>
    public class ReturnVehicleOutput(Guid rentalId, DateTime realEndDate, string message)
    {
        /// <summary>
        /// Gets the unique identifier of the rented vehicle.
        /// </summary>
        public Guid RentalId { get; } = rentalId;

        /// <summary>
        /// Gets the real end date of the rental period (return date).
        /// </summary>
        public DateTime? RealEndDate { get; } = realEndDate;

        /// <summary>
        /// Gets the system message.
        /// </summary>
        public string Message { get; } = message;
    }
}
