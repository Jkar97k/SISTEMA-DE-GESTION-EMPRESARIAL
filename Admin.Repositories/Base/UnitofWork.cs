using Admin.Entities.Modelos;
using Admin.Interfaces.Repositories.Repositories;
using Admin.Repositories.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repositories.Base
{
    public class UnitofWork : IUnitofWork
    {
        private readonly SgeAdminContext _context;
        private ICargoRepository _cargoRepository;

        public UnitofWork(SgeAdminContext context)
        {
            _context = context;
        }

        public ICargoRepository CargoRepository => _cargoRepository ??= new CargoRepository(_context);

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
