using Application.Business.Requests.Abstractions;
using System;

namespace Application.Business.Requests.Users
{
    public class UsersListItemModel : ListItemModel
    {
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
