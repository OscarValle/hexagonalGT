using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.RegisterVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    public class RegisterVehicleFunctionalTests(CompositionRootTestFixture fixture) : FunctionalTestBase(fixture)
    {
        [Fact]
        public async Task ExecuteShouldRegisterVehicleAndPersistToDatabase()
        {
            var licensePlate = "1245ADF";
            var brand = "Audi";
            var model = "A7";

            // ARRANGE
            var request = new RegisterVehicleRequest
            {
                RegistrationPlate = licensePlate,
                Brand = brand,
                Model = model,
                ManufacturingDate = DateTime.Now
            };

            IWebApiPresenter resultPresenter = null;

            await Fixture.UsingHandlerForRequestResponse<RegisterVehicleRequest, IWebApiPresenter>(async handler =>
            {
                // ACT: Invocar el Handle
                resultPresenter = await handler.Handle(request, CancellationToken.None);

                // ASSERT 1
                Assert.NotNull(resultPresenter);
                Assert.IsType<RegisterVehiclePresenter>(resultPresenter);
            });

            await Fixture.UsingRepository<IVehicleRepository>(async repository =>
            {
                var savedVehicle = await repository.GetByPlateAsync(licensePlate);

                // ASSERT 2
                Assert.Equal(licensePlate, savedVehicle.RegistrationPlate);
                Assert.Equal(brand, savedVehicle.Brand);
            });
        }
    }
}
