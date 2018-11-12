using Application.Business.Interfaces;
using Application.Domain.Entities;
using Application.Domain.SeedWork;
using Application.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        private readonly ILogger<AppDbContext> logger;
        private readonly IEventDispatcher dispatcher;

        public AppDbContext(DbContextOptions options, ILogger<AppDbContext> logger, IEventDispatcher dispatcher) : base(options)
        {
            this.dispatcher = dispatcher;
            this.logger = logger;
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Get all changed entities with non dispatched domain events 
            var entities = ChangeTracker.Entries<BaseEntity>()
                .Select(po => po.Entity)
                .Where(po => po.DomainEvents.Any())
                .ToArray();

            // Persist all context changes so events can be dispatched
            var result = await base.SaveChangesAsync(cancellationToken);

            // Now that the context is saved, we dispatch the events
            DispatchDomainEvents(entities);

            // Number of state entries written to the database
            return result;
        }

        protected void DispatchDomainEvents(IEnumerable<BaseEntity> entities)
        {
            if (dispatcher == null)
            {
                logger.LogWarning($"'{nameof(dispatcher)}' is null. Domain events won't be dispatched.");
                return;
            }

            if (entities == null)
            {
                return;
            }

            foreach (var entity in entities)
            {
                var events = entity.DomainEvents.ToArray();

                foreach (var domainEvent in events)
                {
                    dispatcher.Dispatch(domainEvent);
                }

                entity.DomainEvents.Clear();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }
    }
}