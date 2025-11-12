using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Entities;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.ApplicationCore
{
    /// <summary>
    /// Unit tests for <see cref="RegisterVehicleUseCase"/>.
    /// </summary>
    public sealed class RegisterVehicleUseCaseTests
    {
        /// <summary>
        /// Unit test for the Execute method of RegisterVehicleUseCase.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact(DisplayName = "Execute must register a vehicle and call standard output.")]
        public async Task ExecuteShouldRegisterVehicleAndCallOutput()
        {
            // Arrange
            var repoMock = new Mock<IVehicleRepository>();
            var outputMock = new Mock<IRegisterVehicleOutputPort>();

            var useCase = new RegisterVehicleUseCase(repoMock.Object, outputMock.Object);
            var input = new RegisterVehicleInput("1234XYZ", "Audi", "A8", DateTime.Now);

            // Act
            await useCase.Execute(input);

            // Assert
            repoMock.Verify(r => r.AddAsync(It.IsAny<Vehicle>()), Times.Once);
            outputMock.Verify(o => o.Ok(It.IsAny<RegisterVehicleOutput>()), Times.Once);
        }
    }
}
