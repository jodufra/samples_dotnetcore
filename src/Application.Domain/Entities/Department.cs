using Application.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.Entities
{
    public class Department : BaseEntity
    {
        public Department()
        {
            Courses = new HashSet<Course>();
        }

        public int? UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public User Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
