using DominoApplication.Domain.Entities;
using MongoDB.Bson.Serialization;
using System;

namespace DominoApplication.Persistence.Configurations
{
    public static class Configurations
    {
        public static bool IsRegistered = false;
        public static void Configure()
        {
            TryRegisterClassMap<Game>(m =>
            {
                m.AutoMap();
                m.MapIdProperty(c => c.Id);

            });
            IsRegistered = true;
        }

        public static void TryRegisterClassMap<T>(Action<BsonClassMap<T>> classMapInitializer = null)
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(T)) && !IsRegistered)
            {
                if (classMapInitializer == null)
                {
                    BsonClassMap.RegisterClassMap<T>();
                }
                else
                {
                    BsonClassMap.RegisterClassMap<T>(classMapInitializer);
                }
            }
        }
    }
}
