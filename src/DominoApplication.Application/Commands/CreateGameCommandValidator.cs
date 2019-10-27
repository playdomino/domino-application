using FluentValidation;
using System;

namespace DominoApplication.Application.Commands
{
    public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
    {
        public CreateGameCommandValidator()
        {
        }
    }
}