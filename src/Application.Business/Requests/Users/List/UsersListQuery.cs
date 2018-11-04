using Application.Business.Requests.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Business.Requests.Users
{
    public class UsersListQuery : ListQuery<UsersListModel, UsersListItemModel>
    {
        public string Search { get; set; }
    }
}
