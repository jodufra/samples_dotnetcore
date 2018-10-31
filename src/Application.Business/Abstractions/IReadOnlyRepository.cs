using System.Collections.Generic;
using Application.Domain.Abstractions;

namespace Application.Business.Abstractions
{
    public interface IReadOnlyRepository<T> where T : class, IEntity, new()
    {
        T GetById(int id);
        List<T> GetAll();
    }
}