using Application.Domain.SeedWork;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Interfaces
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Asynchronously adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="saveChanges">if set to <c>true</c> [save changes].</param>
        /// <param name="cancellationToken">Token that notifies the operation to be canceled.</param>
        /// <returns></returns>
        Task AddAsync(T entity, bool saveChanges = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="saveChanges">if set to <c>true</c> [save changes].</param>
        /// <param name="cancellationToken">Token that notifies the operation to be canceled.</param>
        /// <returns></returns>
        Task RemoveAsync(T entity, bool saveChanges = default, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="saveChanges">if set to <c>true</c> [save changes].</param>
        /// <param name="cancellationToken">Token that notifies the operation to be canceled.</param>
        /// <returns></returns>
        Task UpdateAsync(T entity, bool saveChanges = default, CancellationToken cancellationToken = default);
    }
}
