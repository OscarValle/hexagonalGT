using System;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.RegisterRentals
{
    public class RegisterRentalPresenter : IRegisterRentalOutputPort, IWebApiPresenter
    {
        public IActionResult ActionResult { get; private set; } = new StatusCodeResult(500);

        public void Ok(RegisterRentalOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            ActionResult = new OkObjectResult(new { output.RentalId, output.VehicleId, output.Message });
        }

        public void InvalidRental(string reason)
        {
            ActionResult = new BadRequestObjectResult(new { Error = reason });
        }

        public void PersonNotMoreThanOneATime(string reason)
        {
            ActionResult = new BadRequestObjectResult(new { Error = reason });
        }
    }
}
