using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Requests.Entities
{
    public class EntityDetailModel : DetailModel
    {
        public string Name { get; set; }
    }

    public class EntityDetailQuery : DetailQuery<EntityDetailModel>
    {
    }

    public class EntityDetailQueryValidator : DetailQueryValidator<EntityDetailQuery, EntityDetailModel>
    {
    }

    public class EntityDetailQueryHandler : DetailQueryHandler<EntityDetailQuery, EntityDetailModel, Entity>
    {
        public EntityDetailQueryHandler(IReadOnlyRepository<Entity> repository) : base(repository)
        {
        }
    }
}
