using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.Entities
{
    public class CreateEntityCommand : CreateCommand
    {
        public string Name { get; set; }
    }

    public class CreateEntityCommandValidator : CreateCommandValidator<CreateEntityCommand>
    {
        public CreateEntityCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class CreateEntityCommandHandler : CreateCommandHandler<CreateEntityCommand, Entity>
    {
        public CreateEntityCommandHandler(IRepository<Entity> repository) : base(repository)
        {
        }
    }
}
