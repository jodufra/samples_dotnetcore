using System.Collections.Generic;
using Application.Domain.Abstractions;

namespace Application.Business.Abstractions
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : class, IEntity, new()
    {
        T Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
