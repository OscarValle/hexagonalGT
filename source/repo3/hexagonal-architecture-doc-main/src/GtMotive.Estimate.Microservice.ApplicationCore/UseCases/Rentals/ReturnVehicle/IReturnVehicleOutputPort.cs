namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals
{
    /// <summary>
    /// Intercafe of ReturnVehicleOutputPort.
    /// </summary>
    public interface IReturnVehicleOutputPort
    {
        /// <summary>
        /// Get Ok.
        /// </summary>
        /// <param name="output">ReturnVehicleOutput.</param>
        void Ok(ReturnVehicleOutput output);

        /// <summary>
        /// Get ReturnVehicle.
        /// </summary>
        /// <param name="reason">Reason.</param>
        void InvalidReturnVehicle(string reason);
    }
}
