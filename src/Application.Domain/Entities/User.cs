using System;
using System.Collections.Generic;
using Application.Domain.Enumerations;
using Application.Domain.SeedWork;

namespace Application.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Enrollments = new HashSet<Enrollment>();
            Courses = new HashSet<UserCourse>();
        }

        public int EntityId { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }

        public Entity Entity { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<UserCourse> Courses { get; set; }
    }
}
