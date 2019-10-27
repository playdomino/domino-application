using DominoApplication.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace DominoApplication.Application.Queries
{
    public class GetGamesQuery:IRequest<List<Game>>{
        
    }
}
