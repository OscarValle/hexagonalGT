using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rental"/> class.
    /// </summary>
    /// <param name="vehicleId">The unique identifier of the rented vehicle.</param>
    /// <param name="customerId">The unique identifier of the customer who rented the vehicle.</param>
    /// <param name="startDate">The start date of the rental period.</param>
    /// <param name="contractEndDate">The end date of the rental period.</param>
    /// <param name="realEndDate">The real end date of the rental period (real return date).</param>
    public class Rental(Guid vehicleId, string customerId, DateTime? startDate, DateTime? contractEndDate, DateTime? realEndDate = null)
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
        /// Gets the end date of the rental period (planned end date).
        /// </summary>
        public DateTime? EndDate { get; private set; } = contractEndDate;

        /// <summary>
        /// Gets the contract end date of the rental period.
        /// </summary>
        public DateTime? ContractEndDate { get; private set; } = contractEndDate;

        /// <summary>
        /// Gets the actual end date (real return date) of the vehicle.
        /// </summary>
        public DateTime? RealEndDate { get; private set; } = realEndDate;

        /// <summary>
        /// Checks if the rental is active relative to a specific reference date.
        /// </summary>
        /// <param name="referenceDate">The date considered "today" for evaluation.</param>
        /// <returns>Is Currently Active.</returns>
        public bool IsCurrentlyActive(DateTime referenceDate)
        {
            return !RealEndDate.HasValue && referenceDate.Date >= StartDate.Value && referenceDate.Date <= EndDate.Value;
        }

        /// <summary>
        /// Checks if the rental is closed now.
        /// </summary>
        /// <returns>Is closed.</returns>
        public bool IsClosed()
        {
            return RealEndDate.HasValue;
        }

        /// <summary>
        /// Marks the rental as completed by setting the RealEndDate.
        /// </summary>
        /// <param name="actualReturnDate">The date of real return.</param>
        public void CloseRental(DateTime actualReturnDate)
        {
            if (RealEndDate.HasValue)
            {
                throw new InvalidOperationException("This rental has already been returned.");
            }

            EndDate = actualReturnDate;
            RealEndDate = actualReturnDate;
        }
    }
}
