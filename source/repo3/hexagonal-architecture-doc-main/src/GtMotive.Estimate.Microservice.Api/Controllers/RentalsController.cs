using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Rentals.RegisterRentals;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> RegisterRental([FromBody] RegisterRentalRequest request)
            => (await _mediator.Send(request)).ActionResult;
    }
}
