using Application.Domain.SeedWork;
using System.Collections.Generic;

namespace Application.Domain.Entities
{
    public class Course : BaseEntity
    {
        public Course()
        {
            Instructors = new HashSet<UserCourse>();
            Enrollments = new HashSet<Enrollment>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public Department Department { get; set; }
        public ICollection<UserCourse> Instructors { get; set; }
        public ICollection<Enrollment> Enrollments{ get; set; }
    }
}