using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Infrastructure
{
    /// <summary>
    /// Unit tests for <see cref="VehicleRepository"/>.
    /// </summary>
    public sealed class VehicleRepositoryTests
    {
        /// <summary>
        /// Unit test for <see cref="VehicleRepository.AddAsync(Vehicle)"/>.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact(DisplayName = "AddAsync must insert a vehicle into the Mongo collection.")]
        public async Task AddAsyncShouldInsertVehicle()
        {
            // Arrange
            var mockCollection = new Mock<IMongoCollection<Vehicle>>();
            var mockDatabase = new Mock<IMongoDatabase>();
            var mockClient = new Mock<IMongoClient>();

            mockDatabase
                .Setup(db => db.GetCollection<Vehicle>("Vehicles", null))
                .Returns(mockCollection.Object);

            mockClient
                .Setup(c => c.GetDatabase(It.IsAny<string>(), null))
                .Returns(mockDatabase.Object);

            var mockOptions = new Mock<IOptions<MongoDbSettings>>();
            mockOptions.Setup(o => o.Value).Returns(new MongoDbSettings
            {
                MongoDbDatabaseName = "TestDb"
            });

            // Mock
            var mockMongoService = new Mock<IMongoService>();
            mockMongoService.SetupGet(s => s.Database).Returns(mockDatabase.Object);
            mockMongoService.SetupGet(s => s.MongoClient).Returns(mockClient.Object);

            var repository = new VehicleRepository(mockMongoService.Object, mockOptions.Object);
            var vehicle = new Vehicle("1234XYZ", "Audi", "A3", DateTime.Now);

            // Act
            await repository.AddAsync(vehicle);

            // Assert
            mockCollection.Verify(
                c => c.InsertOneAsync(vehicle, null, default),
                Times.Once,
                "The vehicle should have been inserted exactly once into the collection.'.");
        }
    }
}
