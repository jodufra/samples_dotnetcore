using System;
using System.Collections.Generic;
using Application.Domain.Infrastructure;

namespace Application.Domain.Entities
{
    public class Entity : BaseEntity
    {
        public Entity()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; }

        public ICollection<User> Users { get; private set; }
    }
}
