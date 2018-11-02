using Application.Business.Commands.Abstractions;
using FluentValidation;

namespace Application.Business.Commands.Users
{
    public class CreateUserCommandValidator : CreateCommandValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(q => q.AccountId).GreaterThan(0);
            RuleFor(q => q.Name).NotEmpty();
        }
    }
}
