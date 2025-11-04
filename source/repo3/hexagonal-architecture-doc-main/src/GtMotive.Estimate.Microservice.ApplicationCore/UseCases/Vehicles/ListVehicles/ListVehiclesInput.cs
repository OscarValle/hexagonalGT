using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListVehicles
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListVehiclesInput"/> class.
    /// </summary>
    /// <param name="startDate">StartDate filter.</param>
    /// <param name="endDate">EndDate filter.</param>
    public sealed class ListVehiclesInput(DateTime startDate, DateTime endDate) : IUseCaseInput
    {
        /// <summary>
        /// Gets is StartDate filter.
        /// </summary>
        public DateTime StartDate { get; } = startDate;

        /// <summary>
        /// Gets is EndDate filter.
        /// </summary>
        public DateTime EndDate { get; } = endDate;
    }
}
