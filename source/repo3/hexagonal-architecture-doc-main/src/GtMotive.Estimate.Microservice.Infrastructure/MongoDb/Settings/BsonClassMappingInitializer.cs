using GtMotive.Estimate.Microservice.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings
{
    public static class BsonClassMappingInitializer
    {
        /// <summary>
        /// Registers all necessary Bson Class Maps for the Domain Entities.
        /// </summary>
        public static void RegisterBsonClasses()
        {
            // Registrar Vehicle
            if (!BsonClassMap.IsClassMapRegistered(typeof(Vehicle)))
            {
                BsonClassMap.RegisterClassMap<Vehicle>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdProperty(v => v.Id)
                      .SetSerializer(new GuidSerializer(GuidRepresentation.Standard));
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(Rental)))
            {
                BsonClassMap.RegisterClassMap<Rental>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdProperty(r => r.Id)
                      .SetSerializer(new GuidSerializer(GuidRepresentation.Standard));
                });
            }
        }
    }
}
