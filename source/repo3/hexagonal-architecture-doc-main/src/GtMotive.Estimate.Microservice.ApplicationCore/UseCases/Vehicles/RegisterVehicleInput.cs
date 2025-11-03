using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterVehicleInput"/> class.
    /// </summary>
    /// <param name="licensePlate">License number.</param>
    /// <param name="brand">Brand.</param>
    /// <param name="model">Model.</param>
    /// <param name="manufacturingDate">Manufacturing date.</param>
    public class RegisterVehicleInput(string licensePlate, string brand, string model, DateTime? manufacturingDate) : IUseCaseInput
    {
        /// <summary>
        /// Gets the registration plate number.
        /// </summary>
        public string LicensePlate { get; } = licensePlate;

        /// <summary>
        /// Gets the vehicle brand.
        /// </summary>
        public string Brand { get; } = brand;

        /// <summary>
        /// Gets the vehicle model.
        /// </summary>
        public string Model { get; } = model;

        /// <summary>
        /// Gets the manufacturing date.
        /// </summary>
        public DateTime? ManufacturingDate { get; private set; } = manufacturingDate;
    }
}
