namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListVehicles
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListVehiclesInput"/> class.
    /// </summary>
    /// <param name="isAvailable">Is Available filter.</param>
    public sealed class ListVehiclesInput(bool? isAvailable) : IUseCaseInput
    {
        /// <summary>
        /// Gets is Available filter.
        /// </summary>
        public bool? IsAvailable { get; } = isAvailable;
    }
}
