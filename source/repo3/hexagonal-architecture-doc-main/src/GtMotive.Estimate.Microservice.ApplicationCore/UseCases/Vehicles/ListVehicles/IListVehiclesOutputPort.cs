namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListVehicles
{
    /// <summary>
    /// Intercafe of IListVehiclesOutputPort.
    /// </summary>
    public interface IListVehiclesOutputPort
    {
        /// <summary>
        /// Get ListVehiclesOutput.
        /// </summary>
        /// <param name="output">ListVehiclesOutput.</param>
        void StandardHandle(ListVehiclesOutput output);
    }
}
