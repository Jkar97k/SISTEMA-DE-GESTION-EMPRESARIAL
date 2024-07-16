
using System.Linq.Expressions;

namespace Admin.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        void DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T?> GetOne(Expression<Func<T, bool>> funcion);
        Task<int> SaveChanges();
        void UpdateAsync(T entity);
    }
}