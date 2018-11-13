using Application.Domain.SeedWork;
using System.Collections.Generic;

namespace Application.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {
            Enrollments = new HashSet<Enrollment>();
            Courses = new HashSet<UserCourse>();
            Address = Address.Empty;
            Cellphone = Phone.Empty;
            Telephone = Phone.Empty;
        }

        public int UserTypeId { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public Phone Cellphone { get; set; }

        public Phone Telephone { get; set; }

        public UserType UserType { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public ICollection<UserCourse> Courses { get; set; }
    }
}
