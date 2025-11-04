using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.ReturnVehicles
{
    public class ReturnVehiclePresenter : IReturnVehicleOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; } = new StatusCodeResult(500);

        public void Ok(ReturnVehicleOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            ActionResult = new OkObjectResult(new { output.RentalId, output.RealEndDate, output.Message });
        }

        public void InvalidReturnVehicle(string reason)
        {
            ActionResult = new BadRequestObjectResult(new { Error = reason });
        }
    }
}
