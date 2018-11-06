using System;
using System.Collections.Generic;
using System.Text;
using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Requests.Departments
{
    public class DepartmentsListItemModel : ListItemModel
    {
    }

    public class DepartmentsListModel : ListModel<DepartmentsListItemModel>
    {
    }

    public class DepartmentsListQuery : ListQuery<DepartmentsListModel, DepartmentsListItemModel>
    {
    }

    public class DepartmentsListQueryValidator : ListQueryValidator<DepartmentsListQuery, DepartmentsListModel, DepartmentsListItemModel>
    {
    }

    public class DepartmentsListQueryHandler : ListQueryHandler<DepartmentsListQuery, DepartmentsListModel, DepartmentsListItemModel, Department>
    {
        public DepartmentsListQueryHandler(IReadOnlyRepository<Department> repository) : base(repository)
        {
        }
    }
}
