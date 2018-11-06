using System;
using System.Collections.Generic;
using Application.Domain.Enumerations;
using Application.Domain.Infrastructure;

namespace Application.Domain.Entities
{
    public class UserCourse : BaseEntity
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
