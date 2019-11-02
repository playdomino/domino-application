using DominoApplication.Domain.Enums;
using System;
using System.Collections.Generic;

namespace DominoApplication.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Avatar { get; set; }
        public PlayerState PlayerState { get; set; }
        public PlayerRole PlayerRole { get; set; }
        public int Order { get; set; }

    }
}
