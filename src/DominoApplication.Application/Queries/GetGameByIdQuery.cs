using MediatR;
using System;
using System.Text;

namespace DominoApplication.Application.Queries
{
    public class GetGameByIdQuery : IRequest<GetGameByIdQueryDto>
    {
        public Guid Id { get; set; }
    }
}
