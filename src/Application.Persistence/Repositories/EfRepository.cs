using Application.Business.Infrastructure;
using Application.Common;
using Application.Domain.Infrastructure;
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

        public List<TEntity> List()
        {
            var t = ListAsync(default);
            t.Wait();
            return t.Result;
        }

        public TEntity FindById(int id)
        {
            var t = FindByIdAsync(id, default);
            t.Wait();
            return t.Result;
        }

        public RepositoryResult<TEntity> Find(RepositoryRequest<TEntity> request)
        {
            var t = FindAsync(request, default);
            t.Wait();
            return t.Result;
        }

        public void Add(TEntity entity)
        {
            AddAsync(entity, default).Wait();
        }

        public void Remove(TEntity entity)
        {
            RemoveAsync(entity, default).Wait();
        }

        public void Update(TEntity entity)
        {
            UpdateAsync(entity, default).Wait();
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
            entity.DateCreated = dateTime.Now;

            context.Set<TEntity>().Add(entity);
            return context.SaveChangesAsync(cancellationToken);
        }

        public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken)
        {
            context.Set<TEntity>().Remove(entity);
            return context.SaveChangesAsync(cancellationToken);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            entity.DateUpdated = dateTime.Now;

            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
