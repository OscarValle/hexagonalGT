using System;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ListVehicles
{
    public sealed class ListVehiclesRequest(DateTime startDate, DateTime endDate) : IRequest<IWebApiPresenter>
    {
        public DateTime StartDate { get; } = startDate;

        public DateTime EndDate { get; } = endDate;
    }
}
