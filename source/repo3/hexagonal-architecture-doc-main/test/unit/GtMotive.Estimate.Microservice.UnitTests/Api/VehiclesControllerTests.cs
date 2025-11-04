using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.Controllers;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.RegisterVehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Api
{
    public sealed class VehiclesControllerTests
    {
        [Fact(DisplayName = "Register must return 200 OK when the request is valid.")]
        public async Task RegisterShouldReturnOkWhenRequestIsValid()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<RegisterVehicleRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Mock.Of<IWebApiPresenter>());

            var controller = new VehiclesController(mediatorMock.Object);
            var request = new RegisterVehicleRequest
            {
                RegistrationPlate = "1234XYZ",
                Brand = "Toyota",
                Model = "Corolla",
                ManufacturingDate = DateTime.Now
            };

            // Act
            var result = await controller.RegisterVehicle(request);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, actionResult.StatusCode);
        }

        [Fact(DisplayName = "Register should return 400 BadRequest when the model is invalid.")]
        public async Task RegisterShouldReturnBadRequestWhenModelIsInvalid()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var controller = new VehiclesController(mediatorMock.Object);
            controller.ModelState.AddModelError("Brand", "Required");

            // Act
            var result = await controller.RegisterVehicle(new RegisterVehicleRequest());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
