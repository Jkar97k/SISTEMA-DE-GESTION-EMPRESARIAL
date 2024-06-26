using Admin.Entities.Modelos;
using Admin.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddAsync(T entity)
        {
            _dbSet.Add(entity);
        }

        public void UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void DeleteAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAllAsync()
        {
            return _dbSet.ToList();
        }
    }
}
