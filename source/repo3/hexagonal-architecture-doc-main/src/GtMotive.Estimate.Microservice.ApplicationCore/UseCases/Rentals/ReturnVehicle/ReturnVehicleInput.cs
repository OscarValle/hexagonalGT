using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReturnVehicleInput"/> class.
    /// </summary>
    /// <param name="rentalId">The unique identifier of the rental.</param>
    /// <param name="realEndDate">The end date of the rental  (return date).</param>
    /// public sealed record ReturnVehicleInput(Guid RentalId, DateTime RealEndDate);
    public class ReturnVehicleInput(Guid rentalId, DateTime? realEndDate) : IUseCaseInput
    {
        /// <summary>
        /// Gets the unique identifier of the rented vehicle.
        /// </summary>
        public Guid RentalId { get; } = rentalId;

        /// <summary>
        /// Gets the real end date of the rental period (return date).
        /// </summary>
        public DateTime? RealEndDate { get; } = realEndDate;
    }
}
