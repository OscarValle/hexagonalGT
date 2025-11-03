using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.RegisterRentals
{
    public class RegisterRentalHandler(IRegisterRentalUseCase useCase, IRegisterRentalOutputPort presenter) : IRequestHandler<RegisterRentalRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(RegisterRentalRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await useCase.Execute(new RegisterRentalInput(request.VehicleId, request.CustomerId, request.StartDate, request.EndDate));
            return (RegisterRentalPresenter)presenter;
        }
    }
}
