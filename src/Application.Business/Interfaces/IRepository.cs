using Application.Domain.SeedWork;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Interfaces
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : BaseEntity
    {
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Adds the specified entity and asynchronously saves all unit of work changes.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">Token that notifies the operation to be canceled.</param>
        /// <returns></returns>
        Task AddAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Removes the specified entity and asynchronously saves all unit of work changes.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">Token that notifies the operation to be canceled.</param>
        /// <returns></returns>
        Task RemoveAsync(T entity, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the specified entity and asynchronously saves all unit of work changes.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">Token that notifies the operation to be canceled.</param>
        /// <returns></returns>
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}
