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
        private readonly IMongoDbContext dbContext;

        public CreateGameCommandHandler(IMongoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = new Game()
            {
                Id = Guid.NewGuid(),
                RoomNumber = request.RoomNumber
            };
            await dbContext.GameCollection.InsertOneAsync(game);
            return game.Id;
        }
    }
}
