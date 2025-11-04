using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ModelViews
{
    public sealed class VehicleResponse(Guid id, string licensePlate, string brand, string model, DateTime? manufactureDate)
    {
        /// <summary>Gets the vehicle ID.</summary>
        [Required]
        public Guid Id { get; } = id;

        /// <summary>Gets the license plate.</summary>
        [Required]
        public string LicensePlate { get; } = licensePlate;

        /// <summary>Gets the brand.</summary>
        [Required]
        public string Brand { get; } = brand;

        /// <summary>Gets the model.</summary>
        [Required]
        public string Model { get; } = model;

        /// <summary>Gets the manufacture date.</summary>
        [Required]
        public DateTime? ManufactureDate { get; } = manufactureDate;
    }
}
