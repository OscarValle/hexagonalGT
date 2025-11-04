using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Specs
{
    [Collection(TestCollections.TestServer)]
    public sealed class VehicleControllerTests : InfrastructureTestBase
    {
        private readonly HttpClient _client;

        public VehicleControllerTests(GenericInfrastructureTestServerFixture fixture)
            : base(fixture)
        {
            ArgumentNullException.ThrowIfNull(fixture);
            _client = fixture.Server.CreateClient();
        }

        [Fact(DisplayName = "POST /api/Vehicles/registerVehicle Should return 400 if the model is not valid")]
        public async Task PostVehicleShouldReturnBadRequestWhenModelIsInvalid()
        {
            // Arrange
            var invalidRequest = new
            {
                LicensePlate = "1245ADF",
                Brand = "Audi",
                Model = "A7"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/Vehicles/registerVehicle", invalidRequest);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "POST /api/Vehicles/registerVehicle Should return 200 if the model is valid")]
        public async Task PostVehicleShouldReturnOkWhenModelIsValid()
        {
            // Arrange
            var validRequest = new
            {
                LicensePlate = "1234XYZ",
                Brand = "Toyota",
                Model = "Corolla",
                ManufacturingDate = DateTime.Now
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/Vehicles/registerVehicle", validRequest);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
