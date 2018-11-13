using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Persistence.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.OwnsOne(o => o.Address);
            builder.OwnsOne(o => o.Cellphone);
            builder.OwnsOne(o => o.Telephone);
        }
    }
}
