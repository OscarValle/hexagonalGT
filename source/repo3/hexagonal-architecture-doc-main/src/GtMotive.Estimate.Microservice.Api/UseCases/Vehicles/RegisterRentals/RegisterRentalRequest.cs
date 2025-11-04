using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.RegisterRentals
{
    public class RegisterRentalRequest : IRequest<IWebApiPresenter>
    {
        [Required]
        public Guid? VehicleId { get; init; }

        [Required]
        public string CustomerId { get; init; }

        [Required]
        public DateTime? StartDate { get; init; }

        [Required]
        public DateTime? EndDate { get; init; }
    }
}
