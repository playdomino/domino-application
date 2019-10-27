using DominoApplication.Domain.Enums;
using System;
using System.Collections.Generic;

namespace DominoApplication.Domain.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public string RoomNumber { get; set; }
        public int Points { get; set; }
        public GameFinishMode GameMode { get; set; }
        public List<GamePlayer> GamePlayers { get; set; }
           
    }
}
