using System;
using System.Collections.Generic;
using Application.Business.Abstractions;
using Application.Common;
using Application.Domain.Abstractions;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Persistence.Repositories
{
    public class EfCachedRepository<T, TRepository> : IReadOnlyRepository<T> where TRepository : IRepository<T> where T : class, IEntity, new()
    {
        private readonly TRepository repository;
        private readonly IMemoryCache cache;
        private readonly string cacheKey;
        private readonly MemoryCacheEntryOptions cacheOptions;

        public EfCachedRepository(TRepository repository, IMemoryCache cache)
        {
            this.repository = repository;
            this.cache = cache;

            cacheKey = typeof(T).Name;
            cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(relative: TimeSpan.FromSeconds(Constants.DEFAULT_CACHE_SECONDS));
        }

        public T GetById(int id)
        {
            var key = $"{cacheKey}-{id}";

            return cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(cacheOptions);
                return repository.GetById(id);
            });
        }

        public virtual List<T> GetAll()
        {
            return cache.GetOrCreate(cacheKey, entry =>
            {
                entry.SetOptions(cacheOptions);
                return repository.GetAll();
            });
        }

    }
}
