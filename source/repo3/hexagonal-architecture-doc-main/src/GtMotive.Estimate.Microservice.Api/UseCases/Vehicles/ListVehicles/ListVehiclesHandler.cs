using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ListVehicles
{
    public sealed class ListVehiclesHandler(IListVehiclesUseCase useCase, IListVehiclesOutputPort presenter) : IRequestHandler<ListVehiclesRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(ListVehiclesRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            var input = new ListVehiclesInput(request.StartDate, request.EndDate);
            await useCase.Execute(input);
            return (ListVehiclesPresenter)presenter;
        }
    }
}
