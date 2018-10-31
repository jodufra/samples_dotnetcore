using System;
using Application.Domain.Enumerations;
using Application.Domain.Abstractions;

namespace Application.Domain.Entities
{
    public class User : IEntity
    {
        public User()
        {
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Account Account { get; set; }
    }
}
