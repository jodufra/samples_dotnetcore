using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Business.Queries.Abstractions
{
    public abstract class DetailQueryValidator<TQuery, TModel> : AbstractValidator<TQuery>
        where TQuery : DetailQuery<TModel>
        where TModel : DetailModel
    {
        protected DetailQueryValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }
}
