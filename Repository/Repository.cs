using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Auth.Repositories
{
#nullable enable
    public class Repository<T, TContext> : IRepository<T> where T : class where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<T> _dbSet;
        //protected readonly IMapper _mapper;

        public Repository(TContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
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

        public async Task<int> SaveChanges()
        {
           return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T?> GetOne(Expression<Func<T, bool>> funcion)
        {
            return await _dbSet.AsNoTracking().Where(funcion).FirstOrDefaultAsync();
        }
    }
}
