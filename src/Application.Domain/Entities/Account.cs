using System;
using System.Collections.Generic;
using Application.Domain.Abstractions;

namespace Application.Domain.Entities
{
    public class Account : IEntity
    {
        public Account()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public ICollection<User> Users { get; private set; }
    }
}
