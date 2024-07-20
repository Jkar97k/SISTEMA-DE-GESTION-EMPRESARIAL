
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Interfaces
{
    public interface IRepository<T,Tcontext> where T : class where Tcontext : DbContext
    {
        Task Add(T entity);
        void DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true);
        Task<T?> GetOne(Expression<Func<T, bool>> funcion);
        Task<int> SaveChanges();
        void UpdateAsync(T entity);
    }
}