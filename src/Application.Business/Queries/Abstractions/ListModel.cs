using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Business.Queries.Abstractions
{
    public abstract class ListModel<TItemModel>
        where TItemModel : ListItemModel
    {
        protected ListModel()
        {
        }

        protected ListModel(List<TItemModel> items, int itemsCount, int totalCount)
        {
            Items = items;
            ItemsCount = itemsCount;
            TotalCount = totalCount;
        }

        public List<TItemModel> Items { get; set; }
        public int ItemsCount { get; set; }
        public int TotalCount { get; set; }
    }
}
