namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// Intercafe to RegisterVehicleOutputPort.
    /// </summary>
    public interface IRegisterVehicleOutputPort
    {
        /// <summary>
        /// Get Ok.
        /// </summary>
        /// <param name="output">RegisterVehicleOutput.</param>
        void Ok(RegisterVehicleOutput output);

        /// <summary>
        /// Get InvalidVehicle.
        /// </summary>
        /// <param name="reason">Reason.</param>
        void InvalidVehicle(string reason);

        /// <summary>
        /// Get VehicleTooOld.
        /// </summary>
        /// <param name="reason">Reason.</param>
        void VehicleTooOld(string reason);
    }
}
