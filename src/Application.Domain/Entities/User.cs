﻿using System;
using Application.Domain.Enumerations;
using Application.Domain.Infrastructure;

namespace Application.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {
        }

        public int AccountId { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }

        public Account Account { get; set; }
    }
}
