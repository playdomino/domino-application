using Mongo.Migration.Documents.Attributes;
using System;
using System.Collections.Generic;

namespace DominoApplication.Domain.Entities
{
    [StartUpVersion("0.0.1")]
    [CollectionLocation(Const.Game, Const.DataBase)]
    public class Game : EntityBase
    {
        public Guid Id { get; set; }
        public string RoomNumber { get; set; }
        public List<Player> GamePlayers { get; set; }
        public GameState GameState { get; set; }
    }
}
