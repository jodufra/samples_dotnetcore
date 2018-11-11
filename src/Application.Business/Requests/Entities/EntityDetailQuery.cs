using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Entities
{
    public class EntityDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }
    }

    public class EntityDetailQuery : IRequest<EntityDetailModel>
    {
        public int Id { get; set; }
    }

    public class EntityDetailQueryValidator : AbstractValidator<EntityDetailModel>
    {
        public EntityDetailQueryValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }

    public class EntityDetailQueryHandler : IRequestHandler<EntityDetailQuery, EntityDetailModel>
    {
        private readonly IMapper mapper;
        private readonly IReadOnlyRepository<Entity> repository;

        public EntityDetailQueryHandler(IReadOnlyRepository<Entity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<EntityDetailModel> Handle(EntityDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(Entity).Name, request.Id);
            }

            return mapper.Map<Entity, EntityDetailModel>(entity);
        }
    }
}
