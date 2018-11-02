using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Domain.Infrastructure;

namespace Application.Business.Infrastructure
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : Entity
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task RemoveAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}
