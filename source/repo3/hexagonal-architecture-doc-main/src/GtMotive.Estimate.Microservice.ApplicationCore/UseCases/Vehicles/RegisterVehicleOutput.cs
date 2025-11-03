namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterVehicleOutput"/> class.
    /// </summary>
    /// <param name="licensePlate">License number.</param>
    /// <param name="message">Message.</param>
    public class RegisterVehicleOutput(string licensePlate, string message)
    {
        /// <summary>
        /// Gets the registration plate number.
        /// </summary>
        public string LicensePlate { get; } = licensePlate;

        /// <summary>
        /// Gets the system message.
        /// </summary>
        public string Message { get; } = message;
    }
}
