using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.RegisterVehicles
{
    public class RegisterVehicleHandler(IRegisterVehicleUseCase useCase, RegisterVehiclePresenter presenter) : IRequestHandler<RegisterVehicleRequest, IWebApiPresenter>
    {
        public async Task<IWebApiPresenter> Handle(RegisterVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await useCase.Execute(new RegisterVehicleInput(request.RegistrationPlate, request.Brand, request.Model, request.ManufacturingDate));
            return presenter;
        }
    }
}
