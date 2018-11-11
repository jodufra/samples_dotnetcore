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
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
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

        public IUnitOfWork UnitOfWork { get => context; }

        public List<TEntity> List()
        {
            return ListAsync(default).GetAwaiter().GetResult();
        }

        public TEntity FindById(int id)
        {
            return FindByIdAsync(id, default).GetAwaiter().GetResult();
        }

        public RepositoryResult<TEntity> Find(RepositoryRequest<TEntity> request)
        {
            return FindAsync(request, default).GetAwaiter().GetResult();
        }

        public void Add(TEntity entity)
        {
            entity.DateCreated = dateTime.Now;

            context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            entity.DateUpdated = dateTime.Now;

            context.Entry(entity).State = EntityState.Modified;
        }

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

        public Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Add(entity);
            return context.SaveChangesAsync(cancellationToken);
        }

        public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Remove(entity);
            return context.SaveChangesAsync(cancellationToken);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            Update(entity);
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
