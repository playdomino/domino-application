using DominoApplication.Domain.Entities;
using MongoDB.Driver;

namespace DominoApplication.Persistence
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(MongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString());
            _database = client.GetDatabase(mongoDbSettings.Database);
            Configurations.Configurations.Configure();
        }

        public IMongoCollection<Game> GameCollection => _database.GetCollection<Game>(Const.Game);

    }
}
