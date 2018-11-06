using Application.Domain.Entities;
using Application.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }
    }
}