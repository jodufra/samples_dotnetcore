using FluentValidation;

namespace Application.Business.Requests.Abstractions
{
    public abstract class ListQueryValidator<TQuery, TModel, TItemModel> : AbstractValidator<TQuery>
        where TQuery : ListQuery<TModel, TItemModel>
        where TModel : ListModel<TItemModel>
        where TItemModel : ListItemModel
    {
        protected ListQueryValidator()
        {
            RuleFor(q => q.PageId).Must(IsNullOrGreaterThan0);
            RuleFor(q => q.PageSize).Must(IsNullOrGreaterThan0);
        }

        public bool IsNullOrGreaterThan0(int? value)
        {
            return !value.HasValue || value.Value > 0;
        }
    }
}
