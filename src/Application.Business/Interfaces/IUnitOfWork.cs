using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Interfaces
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
