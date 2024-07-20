
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Interfaces
{
    public interface IRepository<T,Tcontext> where T : class where Tcontext : DbContext
    {
        Task Add(T entity);
        void DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T?> GetOne(Expression<Func<T, bool>> funcion);
        Task<int> SaveChanges();
        void UpdateAsync(T entity);
    }
}