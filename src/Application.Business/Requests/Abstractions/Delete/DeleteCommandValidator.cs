using FluentValidation;

namespace Application.Business.Requests.Abstractions
{
    public abstract class DeleteCommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : DeleteCommand
    {
        protected DeleteCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }
}
