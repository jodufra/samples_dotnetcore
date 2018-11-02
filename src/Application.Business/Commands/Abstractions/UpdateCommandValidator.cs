using FluentValidation;

namespace Application.Business.Commands.Abstractions
{
    public abstract class UpdateCommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : UpdateCommand
    {
        protected UpdateCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }
}
