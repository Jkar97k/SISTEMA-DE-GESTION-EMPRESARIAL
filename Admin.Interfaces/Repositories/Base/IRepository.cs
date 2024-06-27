﻿
using System.Linq.Expressions;

namespace Admin.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void DeleteAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T?> GetOne(Expression<Func<T, bool>> funcion);
        Task<int> SaveChanges();
        void UpdateAsync(T entity);
    }
}