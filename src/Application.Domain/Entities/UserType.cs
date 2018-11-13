using Application.Domain.SeedWork;

namespace Application.Domain.Entities
{
    public class UserType : Enumeration
    {
        public static UserType Guest = new UserType(1, "Guest");
        public static UserType Student = new UserType(2, "Student");
        public static UserType Teacher = new UserType(3, "Teacher");
        public static UserType Administrator = new UserType(4, "Administrator");

        public UserType(int id, string name) : base(id, name)
        {
        }
    }
}
