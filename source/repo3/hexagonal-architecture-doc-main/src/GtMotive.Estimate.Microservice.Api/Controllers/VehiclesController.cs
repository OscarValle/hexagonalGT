using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ListVehicles;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.RegisterVehicles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> RegisterVehicle([FromBody] RegisterVehicleRequest request)
            => (await _mediator.Send(request)).ActionResult;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVehicles([FromQuery] DateTime startDate, DateTime endDate)
        {
            var presenter = await _mediator.Send(new ListVehiclesRequest(startDate, endDate));
            return presenter.ActionResult;
        }
    }
}
