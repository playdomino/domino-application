using MediatR;
using System;

namespace DominoApplication.Application.Commands
{
    public class CreateGameCommand : IRequest<Guid>
    {
        public string RoomNumber { get; set; }
    }
}
