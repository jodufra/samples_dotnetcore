using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Business.Queries.Abstractions
{
    public abstract class ListQuery<TModel, TItemModel> : IRequest<TModel>
        where TModel : ListModel<TItemModel>
        where TItemModel : ListItemModel
    {
        public int? PageId { get; set; } = 1;
        public int? PageSize { get; set; } = Constants.DEFAULT_PAGE_SIZE;
    }
}
