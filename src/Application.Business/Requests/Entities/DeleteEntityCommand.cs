using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.Entities
{
    public class DeleteEntityCommand : DeleteCommand
    {
    }

    public class DeleteEntityCommandValidator : DeleteCommandValidator<DeleteEntityCommand>
    {
    }

    public class DeleteEntityCommandHandler : DeleteCommandHandler<DeleteEntityCommand, Entity>
    {
        public DeleteEntityCommandHandler(IRepository<Entity> repository) : base(repository)
        {
        }
    }
}
