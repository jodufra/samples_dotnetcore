using Application.Business.Commands.Abstractions;
using FluentValidation;

namespace Application.Business.Commands.Users
{
    public class UpdateUserCommandValidator : UpdateCommandValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(q => q.AccountId).GreaterThan(0);
            RuleFor(q => q.Name).NotEmpty();
        }
    }
}
