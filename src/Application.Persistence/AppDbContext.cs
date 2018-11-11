using Application.Business.Interfaces;
using Application.Domain.Entities;
using Application.Domain.SeedWork;
using Application.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        private readonly IEventDispatcher dispatcher;

        public AppDbContext(DbContextOptions options, IEventDispatcher dispatcher) : base(options)
        {
            this.dispatcher = dispatcher;
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            var entities = GetEntitiesWithDomainEvents();

            var result = base.SaveChanges();

            DispatchDomainEvents(entities);

            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = GetEntitiesWithDomainEvents();

            var result = await base.SaveChangesAsync(cancellationToken);

            DispatchDomainEvents(entities);

            return result;
        }

        private IEnumerable<BaseEntity> GetEntitiesWithDomainEvents()
        {
            return ChangeTracker.Entries<BaseEntity>().Select(po => po.Entity).Where(po => po.DomainEvents.Any()).ToArray();
        }

        private void DispatchDomainEvents(IEnumerable<BaseEntity> entities)
        {
            if (dispatcher is null || entities is null || !entities.Any())
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