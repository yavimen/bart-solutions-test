using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationContext Context { get; set; }

        public RepositoryBase(ApplicationContext context)
        {
            Context = context;
        }

        public IQueryable<T> FindAll() => Context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            Context.Set<T>().Where(expression).AsNoTracking();

        public void Create(T entity) =>
            Context.Set<T>().Add(entity);

        public void Delete(T entity) =>
            Context.Set<T>().Remove(entity);

        public void Update(T entity) =>
            Context.Set<T>().Update(entity);
    }
}