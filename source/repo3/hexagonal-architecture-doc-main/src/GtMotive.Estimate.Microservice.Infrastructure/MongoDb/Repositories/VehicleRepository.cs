using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<Vehicle> _vehiclesCollection;

        public VehicleRepository(MongoService mongoService, IOptions<MongoDbSettings> options)
        {
            ArgumentNullException.ThrowIfNull(mongoService);
            ArgumentNullException.ThrowIfNull(options);

            var database = mongoService.MongoClient.GetDatabase(options.Value.MongoDbDatabaseName);

            _vehiclesCollection = database.GetCollection<Vehicle>("Vehicles");
        }

        public Task AddAsync(Vehicle vehicle) => _vehiclesCollection.InsertOneAsync(vehicle);

        public async Task<Vehicle> GetByIdAsync(Guid id)
        {
            return await _vehiclesCollection.Find(v => v.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetAllExcludingIdsAsync(IEnumerable<Guid> excludedVehicleIds)
        {
            var exclusionFilter = Builders<Vehicle>.Filter.Nin(v => v.Id, excludedVehicleIds);

            return await _vehiclesCollection.Find(exclusionFilter).ToListAsync();
        }
    }
}
