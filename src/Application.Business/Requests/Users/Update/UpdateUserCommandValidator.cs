using Application.Business.Requests.Abstractions;
using FluentValidation;

namespace Application.Business.Requests.Users
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
