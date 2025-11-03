using System.Collections.Generic;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListVehicles
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListVehiclesOutput"/> class.
    /// </summary>
    /// <param name="vehicles">List of vehicles.</param>
    public sealed class ListVehiclesOutput(IEnumerable<Vehicle> vehicles)
    {
        /// <summary>
        /// Gets Vehicles.
        /// </summary>
        public IEnumerable<Vehicle> Vehicles { get; } = vehicles;
    }
}
