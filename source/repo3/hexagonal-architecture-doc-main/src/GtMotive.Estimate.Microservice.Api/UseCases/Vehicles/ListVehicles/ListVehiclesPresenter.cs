using System;
using System.Linq;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ModelViews;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ListVehicles
{
    public sealed class ListVehiclesPresenter : IListVehiclesOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ListVehiclesOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            var vehicles = output.Vehicles.Select(v =>
                new VehicleResponse(v.Id, v.RegistrationPlate, v.Brand, v.Model, v.ManufacturingDate, v.IsAvailable))
            .ToList();

            ActionResult = new OkObjectResult(vehicles);
        }
    }
}
