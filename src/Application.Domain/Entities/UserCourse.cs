using System;
using System.Collections.Generic;
using Application.Domain.SeedWork;

namespace Application.Domain.Entities
{
    public class UserCourse : Entity
    {
        public UserCourse()
        {
        }

        public int UserId { get; set; }
        public int CourseId { get; set; }

        public User User { get; set; }
        public Course Course { get; set; }
    }
}
