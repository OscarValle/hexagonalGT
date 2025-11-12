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
    /// <summary>
    /// Unit tests for <see cref="VehiclesController"/>.
    /// </summary>
    public sealed class VehiclesControllerTests
    {
        /// <summary>
        /// Unit test for the <see cref="VehiclesController.RegisterVehicle(RegisterVehicleRequest)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact(DisplayName = "Register must return 200 OK when the request is valid.")]
        public async Task RegisterShouldReturnOkWhenRequestIsValid()
        {
            // Arrange
            var okResult = new OkObjectResult("Vehicle registered");

            var presenterMock = new Mock<IWebApiPresenter>();
            presenterMock.SetupGet(p => p.ActionResult).Returns(okResult);

            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<RegisterVehicleRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(presenterMock.Object);

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
            Assert.Equal("Vehicle registered", actionResult.Value);
        }

        /// <summary>
        /// Unit test for the <see cref="VehiclesController.RegisterVehicle(RegisterVehicleRequest)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact(DisplayName = "Register should return 400 BadRequest when the model is invalid.")]
        public async Task RegisterShouldReturnBadRequestWhenModelIsInvalid()
        {
            // Arrange
            var badRequestResult = new BadRequestObjectResult("Model is invalid");

            var presenterMock = new Mock<IWebApiPresenter>();
            presenterMock.SetupGet(p => p.ActionResult).Returns(badRequestResult);

            var mediatorMock = new Mock<IMediator>();
            mediatorMock
                .Setup(m => m.Send(It.IsAny<RegisterVehicleRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(presenterMock.Object);

            var controller = new VehiclesController(mediatorMock.Object);

            controller.ModelState.AddModelError("Brand", "Required");

            var request = new RegisterVehicleRequest();

            // Act
            var result = await controller.RegisterVehicle(request);

            // Assert
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, actionResult.StatusCode);
            Assert.Equal("Model is invalid", actionResult.Value);
        }
    }
}
