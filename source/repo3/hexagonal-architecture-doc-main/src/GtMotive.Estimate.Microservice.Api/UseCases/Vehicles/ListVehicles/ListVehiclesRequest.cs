using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ListVehicles
{
    public sealed class ListVehiclesRequest(bool? isAvailable) : IRequest<IWebApiPresenter>
    {
        public bool? IsAvailable { get; } = isAvailable;
    }
}
