
namespace Admin.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetOne(System.Linq.Expressions.Expression<Func<T, bool>> funcion);
        Task SaveChanges();
        Task UpdateAsync(T entity);

    }
}