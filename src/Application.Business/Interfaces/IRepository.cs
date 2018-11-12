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
        /// <param name="saveChanges">if set to <c>true</c> [save changes].</param>
        void Add(T entity, bool saveChanges = true);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="saveChanges">if set to <c>true</c> [save changes].</param>
        void Remove(T entity, bool saveChanges = true);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="saveChanges">if set to <c>true</c> [save changes].</param>
        void Update(T entity, bool saveChanges = true);

        /// <summary>
        /// Asynchronously adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="saveChanges">if set to <c>true</c> [save changes].</param>
        /// <param name="cancellationToken">Token that notifies the operation to be canceled.</param>
        /// <returns></returns>
        Task AddAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="saveChanges">if set to <c>true</c> [save changes].</param>
        /// <param name="cancellationToken">Token that notifies the operation to be canceled.</param>
        /// <returns></returns>
        Task RemoveAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="saveChanges">if set to <c>true</c> [save changes].</param>
        /// <param name="cancellationToken">Token that notifies the operation to be canceled.</param>
        /// <returns></returns>
        Task UpdateAsync(T entity, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}
