using DominoApplication.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DominoApplication.Application.Queries
{

    public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GetGameByIdQueryDto>
    {
        private readonly DataBaseContext dataBaseContext;

        public GetGameByIdQueryHandler(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }

        public Task<GetGameByIdQueryDto> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new GetGameByIdQueryDto();
            var game=dataBaseContext.Games.SingleOrDefault(p => p.Id == request.Id);
            result.RoomNumber = game.RoomNumber;
            return Task.FromResult(result);
        }
    }
}

