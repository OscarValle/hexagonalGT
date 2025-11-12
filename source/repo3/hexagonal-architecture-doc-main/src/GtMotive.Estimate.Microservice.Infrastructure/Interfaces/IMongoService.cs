using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.Interfaces
{
    public interface IMongoService
    {
        IMongoClient MongoClient { get; }

        IMongoDatabase Database { get; }
    }
}
