using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly IMongoCollection<Rental> _rentalsCollection;

        public RentalRepository(MongoService mongoService, IOptions<MongoDbSettings> options)
        {
            ArgumentNullException.ThrowIfNull(mongoService);
            ArgumentNullException.ThrowIfNull(options);

            var database = mongoService.MongoClient.GetDatabase(options.Value.MongoDbDatabaseName);

            _rentalsCollection = database.GetCollection<Rental>("Rentals");
        }

        public Task AddAsync(Rental rental) => _rentalsCollection.InsertOneAsync(rental);

        public Task UpdateAsync(Rental rental) => _rentalsCollection.ReplaceOneAsync(r => r.Id == rental.Id, rental);

        public async Task<IEnumerable<Rental>> GetByCustomerIdAsync(string customerId, bool? isActive)
        {
            var filter = Builders<Rental>.Filter.Eq(r => r.CustomerId, customerId);

            if (isActive.HasValue)
            {
                var isActiveFilter = Builders<Rental>.Filter.Eq(r => r.IsActive, isActive.Value);

                filter = Builders<Rental>.Filter.And(filter, isActiveFilter);
            }

            return await _rentalsCollection.Find(filter).ToListAsync();
        }

        public async Task<Rental> GetByIdAsync(Guid id)
        {
            return await _rentalsCollection.Find(v => v.Id == id).FirstOrDefaultAsync();
        }
    }
}
