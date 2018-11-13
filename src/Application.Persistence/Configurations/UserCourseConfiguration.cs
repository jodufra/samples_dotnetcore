using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Persistence.Configurations
{
    public class UserCourseConfiguration : EntityConfiguration<UserCourse>
    {
        public override void Configure(EntityTypeBuilder<UserCourse> builder)
        {
            base.Configure(builder);
        }
    }
}
