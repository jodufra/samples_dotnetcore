using FluentValidation;

namespace Application.Business.Requests.Abstractions
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
