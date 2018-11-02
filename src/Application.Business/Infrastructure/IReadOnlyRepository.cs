using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Domain.Infrastructure;

namespace Application.Business.Infrastructure
{
    public interface IReadOnlyRepository<T> where T : Entity
    {
        List<T> List();
        T FindById(int id);
        RepositoryResult<T> Find(RepositoryRequest<T> request);
        Task<List<T>> ListAsync(CancellationToken cancellationToken);
        Task<T> FindByIdAsync(int id, CancellationToken cancellationToken);
        Task<RepositoryResult<T>> FindAsync(RepositoryRequest<T> request, CancellationToken cancellationToken);
    }
}