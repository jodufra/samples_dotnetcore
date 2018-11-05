using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.Entities
{
    public class UpdateEntityCommand : UpdateCommand
    {
        public string Name { get; set; }
    }

    public class UpdateEntityCommandValidator : UpdateCommandValidator<UpdateEntityCommand>
    {
        public UpdateEntityCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class UpdateEntityCommandHandler : UpdateCommandHandler<UpdateEntityCommand, Entity>
    {
        public UpdateEntityCommandHandler(IRepository<Entity> repository) : base(repository)
        {
        }
    }
}
