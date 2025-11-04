using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.ReturnVehicles
{
    public class ReturnVehicleHandler(IReturnVehicleUseCase useCase, IReturnVehicleOutputPort presenter) : IRequestHandler<ReturnVehicleRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(ReturnVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await useCase.Execute(new ReturnVehicleInput(request.RentalId.Value, request.RealEndDate));
            return (ReturnVehiclePresenter)presenter;
        }
    }
}
