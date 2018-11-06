using System;
using System.Collections.Generic;
using System.Text;
using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Requests.Courses
{
    public class CoursesListItemModel : ListItemModel
    {
    }

    public class CoursesListModel : ListModel<CoursesListItemModel>
    {
    }

    public class CoursesListQuery : ListQuery<CoursesListModel, CoursesListItemModel>
    {
    }

    public class CoursesListQueryValidator : ListQueryValidator<CoursesListQuery, CoursesListModel, CoursesListItemModel>
    {
    }

    public class CoursesListQueryHandler : ListQueryHandler<CoursesListQuery, CoursesListModel, CoursesListItemModel, Course>
    {
        public CoursesListQueryHandler(IReadOnlyRepository<Course> repository) : base(repository)
        {
        }
    }
}
