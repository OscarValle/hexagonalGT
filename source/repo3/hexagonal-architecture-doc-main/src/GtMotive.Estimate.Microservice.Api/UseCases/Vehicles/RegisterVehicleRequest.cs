using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles
{
    public class RegisterVehicleRequest : IRequest<IWebApiPresenter>
    {
        [Required]
        public string RegistrationPlate { get; init; }

        [Required]
        public string Brand { get; init; }

        [Required]
        public string Model { get; init; }

        [Required]
        public DateTime? ManufacturingDate { get; init; }
    }
}
