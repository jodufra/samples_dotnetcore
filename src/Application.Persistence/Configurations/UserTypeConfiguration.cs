using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Persistence.Configurations
{
    public class UserTypeConfiguration : EnumerationConfiguration<UserType>
    {
        public override void Configure(EntityTypeBuilder<UserType> builder)
        {
            base.Configure(builder);
        }
    }
}
