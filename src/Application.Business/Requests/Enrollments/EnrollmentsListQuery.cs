using System;
using System.Collections.Generic;
using System.Text;
using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Requests.Enrollments
{
    public class EnrollmentsListItemModel : ListItemModel
    {
    }

    public class EnrollmentsListModel : ListModel<EnrollmentsListItemModel>
    {
    }

    public class EnrollmentsListQuery : ListQuery<EnrollmentsListModel, EnrollmentsListItemModel>
    {
    }

    public class EnrollmentsListQueryValidator : ListQueryValidator<EnrollmentsListQuery, EnrollmentsListModel, EnrollmentsListItemModel>
    {
    }

    public class EnrollmentsListQueryHandler : ListQueryHandler<EnrollmentsListQuery, EnrollmentsListModel, EnrollmentsListItemModel, Enrollment>
    {
        public EnrollmentsListQueryHandler(IReadOnlyRepository<Enrollment> repository) : base(repository)
        {
        }
    }
}
