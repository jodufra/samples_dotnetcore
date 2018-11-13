using Application.Business.Interfaces;
using Application.Business.Models;
using Application.Common;
using Application.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Persistence.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly AppDbContext context;
        protected readonly IDateTime dateTime;
        protected readonly IRandom random;

        public EfRepository(AppDbContext context, IDateTime dateTime, IRandom random)
        {
            this.context = context;
            this.random = random;
            this.dateTime = dateTime;
        }

        public IUnitOfWork UnitOfWork => context;

        public Task<TEntity> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            return context.Set<TEntity>().FindAsync(id);
        }

        public Task<List<TEntity>> ListAsync(CancellationToken cancellationToken)
        {
            return context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<RepositoryResult<TEntity>> FindAsync(RepositoryRequest<TEntity> request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new System.ArgumentNullException(nameof(request));
            }

            var query = from q in context.Set<TEntity>() select q;

            if (request.Query != null)
            {
                query = request.Query.ApplyTo(query);
            }

            var totalCount = query.Count();

            if (request.Order != null)
            {
                query = request.Order.ApplyTo(query);
            }

            if (request.PageId.HasValue && request.PageSize.HasValue)
            {
                var skip = (request.PageId.Value - 1) * request.PageSize.Value;
                query = query.Skip(skip).Take(request.PageSize.Value);
            }
            else if (request.PageSize.HasValue && request.PageSize.Value < totalCount)
            {
                var maxSkip = totalCount - request.PageSize.Value;
                var skip = random.Next(0, maxSkip);
                query = query.Skip(skip).Take(request.PageSize.Value);
            }

            var items = await query.ToListAsync(cancellationToken);

            return new RepositoryResult<TEntity>(items, totalCount);
        }

        public Task AddAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            if (entity.IsTransient())
            {
                context.Set<TEntity>().Add(entity);
            }

            return saveChanges ? context.SaveChangesAsync(cancellationToken) : Task.CompletedTask;
        }

        public Task RemoveAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            if (!entity.IsTransient())
            {
                context.Set<TEntity>().Remove(entity);
            }

            return saveChanges ? context.SaveChangesAsync(cancellationToken) : Task.CompletedTask;
        }

        public Task UpdateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            context.Entry(entity).State = EntityState.Modified;

            return saveChanges ? context.SaveChangesAsync(cancellationToken) : Task.CompletedTask;
        }
    }
}
