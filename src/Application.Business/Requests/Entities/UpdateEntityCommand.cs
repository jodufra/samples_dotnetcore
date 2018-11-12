using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Entities
{
    public class UpdateEntityCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateEntityCommandValidator : AbstractValidator<UpdateEntityCommand>
    {
        public UpdateEntityCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class UpdateEntityCommandHandler : IRequestHandler<UpdateEntityCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Entity> repository;

        public UpdateEntityCommandHandler(IRepository<Entity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(Entity).Name, request.Id);
            }

            entity = mapper.Map(request, entity);

            await repository.UpdateAsync(entity, true, cancellationToken);

            return Unit.Value;
        }
    }
}
