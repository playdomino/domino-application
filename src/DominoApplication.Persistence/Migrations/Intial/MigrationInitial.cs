using DominoApplication.Domain.Entities;
using Mongo.Migration.Migrations;
using MongoDB.Bson;

namespace DominoApplication.Persistence.Migrations.Intial
{

    public class GameMigrationInitial : Migration<Game>
    {
        public GameMigrationInitial() : base("0.0.1")
        {
        }
        public override void Up(BsonDocument document)
        {
        }

        public override void Down(BsonDocument document)
        {
        }
    }

}
