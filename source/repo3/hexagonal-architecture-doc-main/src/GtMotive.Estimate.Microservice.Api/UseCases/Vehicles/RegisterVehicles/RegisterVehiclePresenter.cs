using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    public class RegisterVehiclePresenter : IRegisterVehicleOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; } = new StatusCodeResult(500);

        public void Ok(RegisterVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);
            ActionResult = new OkObjectResult(new { output.LicensePlate, output.Message });
        }

        public void InvalidVehicle(string reason)
        {
            ActionResult = new BadRequestObjectResult(new { Error = reason });
        }

        public void VehicleTooOld(string reason)
        {
            ActionResult = new BadRequestObjectResult(new { Error = reason });
        }
    }
}
