using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class MongoService : IMongoService
    {
        public MongoService(IOptions<MongoDbSettings> options)
        {
            var settings = options.Value;

            BsonClassMappingInitializer.RegisterBsonClasses();

            MongoClient = new MongoClient(settings.ConnectionString);
            Database = MongoClient.GetDatabase(settings.MongoDbDatabaseName);
        }

        public MongoClient MongoClient { get; }

        public IMongoDatabase Database { get; }

        IMongoClient IMongoService.MongoClient => MongoClient;
    }
}
