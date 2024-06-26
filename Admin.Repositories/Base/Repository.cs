using Admin.Entities.Modelos;
using Admin.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SgeAdminContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(SgeAdminContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
           return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T?> GetOne(Expression<Func<T, bool>> funcion)
        {
            return await _context.Set<T>().AsNoTracking().Where(funcion).FirstOrDefaultAsync();
        }
    }
}
