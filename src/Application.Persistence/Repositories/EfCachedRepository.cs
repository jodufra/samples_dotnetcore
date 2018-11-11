using Application.Business.Interfaces;
using Application.Business.Models;
using Application.Common;
using Application.Domain.SeedWork;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Persistence.Repositories
{
    public class EfCachedRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> repository;
        private readonly IMemoryCache cache;
        private readonly string cacheKey;
        private readonly MemoryCacheEntryOptions cacheOptions;

        public EfCachedRepository(IRepository<TEntity> repository, IMemoryCache cache)
        {
            this.repository = repository;
            this.cache = cache;

            cacheKey = typeof(TEntity).Name;
            cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(Constants.DEFAULT_CACHE_SECONDS));
        }

        public virtual List<TEntity> List()
        {
            return cache.GetOrCreate(cacheKey, entry =>
            {
                entry.SetOptions(cacheOptions);
                return repository.List();
            });
        }

        public TEntity FindById(int id)
        {
            var key = $"{cacheKey}-{id}";

            return cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(cacheOptions);
                return repository.FindById(id);
            });
        }

        public RepositoryResult<TEntity> Find(RepositoryRequest<TEntity> request)
        {
            var key = $"{cacheKey}-Find-{request.GetHashCode()}";

            return cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(cacheOptions);
                return repository.Find(request);
            });
        }

        public Task<List<TEntity>> ListAsync(CancellationToken cancellationToken)
        {
            return cache.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.SetOptions(cacheOptions);
                return repository.ListAsync(cancellationToken);
            });
        }

        public Task<TEntity> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            var key = $"{cacheKey}-{id}";

            return cache.GetOrCreateAsync(key, entry =>
            {
                entry.SetOptions(cacheOptions);
                return repository.FindByIdAsync(id, cancellationToken);
            });
        }

        public Task<RepositoryResult<TEntity>> FindAsync(RepositoryRequest<TEntity> request, CancellationToken cancellationToken)
        {
            var key = $"{cacheKey}-Find-{request.GetHashCode()}";

            return cache.GetOrCreateAsync(key, entry =>
            {
                entry.SetOptions(cacheOptions);
                return repository.FindAsync(request, cancellationToken);
            });
        }
    }
}
