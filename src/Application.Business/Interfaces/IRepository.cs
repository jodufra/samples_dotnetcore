using Application.Domain.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Interfaces
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task RemoveAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}
