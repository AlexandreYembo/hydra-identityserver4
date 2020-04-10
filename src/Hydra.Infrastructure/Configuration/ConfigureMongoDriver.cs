using MongoDB.Bson.Serialization;

namespace Hydra.Infrastructure.Configuration
{
    public static class ConfigureMongoDriver
    {
        public static void RegisterClassMap<TMap>() => 
            BsonClassMap.RegisterClassMap<TMap>(cm => 
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });
    }
}