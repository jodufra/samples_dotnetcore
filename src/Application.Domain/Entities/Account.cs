using System;
using System.Collections.Generic;
using Application.Domain.Infrastructure;

namespace Application.Domain.Entities
{
    public class Account : Entity
    {
        public Account()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; }

        public ICollection<User> Users { get; private set; }
    }
}
