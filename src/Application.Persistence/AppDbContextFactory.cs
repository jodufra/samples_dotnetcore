using Application.Common;
using Application.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence
{
    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        public AppDbContextFactory() : this(new DesignTimeDirectory())
        {
        }

        public AppDbContextFactory(IDirectory directory) : base(directory)
        {
        }

        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options, new DesignTimeEventDispatcher());
        }
    }
}
