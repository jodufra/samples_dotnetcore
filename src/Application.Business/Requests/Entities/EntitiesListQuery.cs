using System;
using System.Collections.Generic;
using System.Text;
using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Requests.Entities
{
    public class EntitiesListItemModel : ListItemModel
    {
    }

    public class EntitiesListModel : ListModel<EntitiesListItemModel>
    {
    }

    public class EntitiesListQuery : ListQuery<EntitiesListModel, EntitiesListItemModel>
    {
    }

    public class EntitiesListQueryValidator : ListQueryValidator<EntitiesListQuery, EntitiesListModel, EntitiesListItemModel>
    {
    }

    public class EntitiesListQueryHandler : ListQueryHandler<EntitiesListQuery, EntitiesListModel, EntitiesListItemModel, Entity>
    {
        public EntitiesListQueryHandler(IReadOnlyRepository<Entity> repository) : base(repository)
        {
        }
    }
}
