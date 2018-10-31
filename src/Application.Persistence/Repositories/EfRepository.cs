using System.Collections.Generic;
using System.Linq;
using Application.Business.Abstractions;
using Application.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected readonly AppDbContext context;

        public EfRepository(AppDbContext context)
        {
            this.context = context;
        }

        public T GetById(int id)
        {
            return context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public virtual List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
