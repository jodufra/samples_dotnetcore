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
        public DbSet<User> Users { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Get all changed entities with non dispatched domain events 
            var entities = ChangeTracker.Entries<Entity>()
                .Select(po => po.Entity)
                .Where(po => po.DomainEvents.Any());

            // Persist all context changes so events can be dispatched
            var result = await base.SaveChangesAsync(cancellationToken);

            // Now that the context is saved, we dispatch the events
            await DispatchDomainEventsAsync(entities, cancellationToken);

            // Number of state entries written to the database
            return result;
        }

        private async Task DispatchDomainEventsAsync(IEnumerable<Entity> domainEntities, CancellationToken cancellationToken = default)
        {
            if (dispatcher == null)
            {
                logger.LogWarning($"'{nameof(dispatcher)}' is null. Domain events won't be dispatched.");
                return;
            }

            var domainEvents = domainEntities.SelectMany(q => q.DomainEvents).ToList();

            var tasks = domainEvents.Select(async (domainEvent) =>
            {
                await dispatcher.DispatchAsync(domainEvent, cancellationToken);
            });

            await Task.WhenAll(tasks);

            foreach (var entity in domainEntities)
            {
                entity.ClearDomainEvents();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }
    }
}