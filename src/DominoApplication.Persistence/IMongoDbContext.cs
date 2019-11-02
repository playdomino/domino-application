using DominoApplication.Domain.Entities;
using MongoDB.Driver;

namespace DominoApplication.Persistence
{
    public interface IMongoDbContext
    {
        IMongoCollection<Game> GameCollection { get; }
    }
}