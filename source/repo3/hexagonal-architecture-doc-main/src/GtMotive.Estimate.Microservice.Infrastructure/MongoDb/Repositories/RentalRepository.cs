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

        public async Task<IEnumerable<Rental>> GetByCustomerIdAsync(string customerId, bool? isActive, DateTime referenceDate)
        {
            var effectiveReferenceDate = referenceDate;

            var filter = Builders<Rental>.Filter.Eq(r => r.CustomerId, customerId);

            if (isActive.HasValue)
            {
                FilterDefinition<Rental> dateFilter;

                if (isActive.Value)
                {
                    var startedFilter = Builders<Rental>.Filter.Lte(r => r.StartDate, effectiveReferenceDate);
                    var ongoingFilter = Builders<Rental>.Filter.Gte(r => r.EndDate, effectiveReferenceDate);

                    dateFilter = Builders<Rental>.Filter.And(startedFilter, ongoingFilter);
                }
                else
                {
                    var futureFilter = Builders<Rental>.Filter.Gt(r => r.StartDate, effectiveReferenceDate);
                    var finishedFilter = Builders<Rental>.Filter.Lt(r => r.EndDate, effectiveReferenceDate);

                    dateFilter = Builders<Rental>.Filter.Or(futureFilter, finishedFilter);
                }

                filter = Builders<Rental>.Filter.And(filter, dateFilter);
            }

            return await _rentalsCollection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Guid>> GetReservedVehicleIdsAsync(DateTime startDate, DateTime endDate)
        {
            var startsBeforeProposedEnd = Builders<Rental>.Filter.Gte(r => r.EndDate, startDate);
            var endsAfterProposedStart = Builders<Rental>.Filter.Lte(r => r.StartDate, endDate);
            var overlapFilter = Builders<Rental>.Filter.And(startsBeforeProposedEnd, endsAfterProposedStart);

            var distinctResultCursor = await _rentalsCollection.DistinctAsync(
                    field: r => r.VehicleId,
                    filter: overlapFilter);

            return await distinctResultCursor.ToListAsync();
        }

        public async Task<IEnumerable<Rental>> GetOverlappingRentalsAsync(Guid vehicleId, DateTime proposedStartDate, DateTime proposedEndDate)
        {
            var vehicleFilter = Builders<Rental>.Filter.Eq(r => r.VehicleId, vehicleId);

            var startsBeforeProposedEnd = Builders<Rental>.Filter.Gte(r => r.EndDate, proposedStartDate);
            var endsAfterProposedStart = Builders<Rental>.Filter.Lte(r => r.StartDate, proposedEndDate);

            var overlapFilter = Builders<Rental>.Filter.And(startsBeforeProposedEnd, endsAfterProposedStart);

            var filter = Builders<Rental>.Filter.And(vehicleFilter, overlapFilter);

            return await _rentalsCollection.Find(filter).ToListAsync();
        }

        public async Task<Rental> GetByIdAsync(Guid id)
        {
            return await _rentalsCollection.Find(v => v.Id == id).FirstOrDefaultAsync();
        }
    }
}
