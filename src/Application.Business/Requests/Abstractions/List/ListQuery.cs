using Application.Common;
using MediatR;

namespace Application.Business.Requests.Abstractions
{
    public abstract class ListQuery<TModel, TItemModel> : IRequest<TModel>
        where TModel : ListModel<TItemModel>
        where TItemModel : ListItemModel
    {
        protected ListQuery()
        {
            PageId = 1;
            PageSize = Constants.DEFAULT_PAGE_SIZE;
        }

        public int? PageId { get; set; }
        public int? PageSize { get; set; }
    }
}
