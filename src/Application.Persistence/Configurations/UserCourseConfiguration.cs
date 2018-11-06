using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Persistence.Configurations
{
    public class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> builder)
        {
        }
    }
}
