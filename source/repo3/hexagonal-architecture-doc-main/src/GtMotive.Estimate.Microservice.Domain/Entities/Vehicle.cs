using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Vehicle"/> class.
    /// </summary>
    /// <param name="registrationPlate">Plate number.</param>
    /// <param name="brand">Brand.</param>
    /// <param name="model">Model.</param>
    /// <param name="manufacturingDate">Date.</param>
    public class Vehicle(string registrationPlate, string brand, string model, DateTime? manufacturingDate)
    {
        /// <summary>
        /// Gets the unique identifier of the vehicle.
        /// </summary>
        public Guid Id { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// Gets the registration plate number.
        /// </summary>
        public string RegistrationPlate { get; private set; } = registrationPlate;

        /// <summary>
        /// Gets the vehicle brand.
        /// </summary>
        public string Brand { get; private set; } = brand;

        /// <summary>
        /// Gets the vehicle model.
        /// </summary>
        public string Model { get; private set; } = model;

        /// <summary>
        /// Gets the manufacturing date.
        /// </summary>
        public DateTime? ManufacturingDate { get; private set; } = manufacturingDate;
    }
}
