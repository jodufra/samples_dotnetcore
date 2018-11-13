using Application.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Persistence.Configurations
{
    public abstract class EnumerationConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Enumeration
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).HasDefaultValue(1).ValueGeneratedNever().IsRequired();

            builder.Property(o => o.Name).IsRequired();
        }
    }
}
