using FluentValidation;

namespace Application.Business.Commands.Abstractions
{
    public abstract class CreateCommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : CreateCommand
    {

    }
}
