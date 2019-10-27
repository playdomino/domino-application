using DominoApplication.Domain.Entities;
using DominoApplication.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DominoApplication.Application.Commands
{
    public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Guid>
    {
        private readonly DataBaseContext dataBaseContext;

        public CreateGameCommandHandler(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public async Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = new Game()
            {
                Id = Guid.NewGuid(),
                RoomNumber = request.RoomNumber
            };

            dataBaseContext.Add(game);
            await dataBaseContext.SaveChangesAsync();
            return game.Id;
        }
    }
}
