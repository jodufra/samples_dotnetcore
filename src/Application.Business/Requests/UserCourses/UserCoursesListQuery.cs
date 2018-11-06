using System;
using System.Collections.Generic;
using System.Text;
using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Requests.UserCourses
{
    public class UserCoursesListItemModel : ListItemModel
    {
    }

    public class UserCoursesListModel : ListModel<UserCoursesListItemModel>
    {
    }

    public class UserCoursesListQuery : ListQuery<UserCoursesListModel, UserCoursesListItemModel>
    {
    }

    public class UserCoursesListQueryValidator : ListQueryValidator<UserCoursesListQuery, UserCoursesListModel, UserCoursesListItemModel>
    {
    }

    public class UserCoursesListQueryHandler : ListQueryHandler<UserCoursesListQuery, UserCoursesListModel, UserCoursesListItemModel, UserCourse>
    {
        public UserCoursesListQueryHandler(IReadOnlyRepository<UserCourse> repository) : base(repository)
        {
        }
    }
}
