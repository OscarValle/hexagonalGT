using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.ReturnVehicles
{
    public class ReturnVehicleRequest : IRequest<IWebApiPresenter>
    {
        [Required]
        public Guid? RentalId { get; init; }

        [Required]
        public DateTime? RealEndDate { get; init; }
    }
}
