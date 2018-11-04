using FluentValidation;

namespace Application.Business.Requests.Abstractions
{
    public abstract class CreateCommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : CreateCommand
    {

    }
}
