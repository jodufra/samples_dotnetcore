using Application.Business.Models;
using Application.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Interfaces
{
    public interface IReadOnlyRepository<T> where T : Entity
    {
        Task<List<T>> ListAsync(CancellationToken cancellationToken);

        Task<T> FindByIdAsync(int id, CancellationToken cancellationToken);

        Task<RepositoryResult<T>> FindAsync(RepositoryRequest<T> request, CancellationToken cancellationToken);
    }
}