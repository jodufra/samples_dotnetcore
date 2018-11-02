using FluentValidation;

namespace Application.Business.Commands.Abstractions
{
    public abstract class RemoveCommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : RemoveCommand
    {
        protected RemoveCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }
}
