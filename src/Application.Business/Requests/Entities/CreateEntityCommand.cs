using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Entities
{
    public class CreateEntityCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateEntityCommandValidator : AbstractValidator<CreateEntityCommand>
    {
        public CreateEntityCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class CreateEntityCommandHandler : IRequestHandler<CreateEntityCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Entity> repository;

        public CreateEntityCommandHandler(IRepository<Entity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CreateEntityCommand, Entity>(request);

            await repository.AddAsync(entity, cancellationToken);

            return entity.Id;
        }
    }
}
