using Application.Business.Requests.Abstractions;
using FluentValidation;

namespace Application.Business.Requests.Users
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
