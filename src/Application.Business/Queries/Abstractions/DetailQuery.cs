using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Business.Queries.Abstractions
{
    public abstract class DetailQuery<TModel> : IRequest<TModel>
        where TModel : DetailModel
    {
        public int Id { get; set; }
    }
}
