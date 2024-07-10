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
        private IArlRepository _arlRepository;
        private ICecoRepository _ccoRepository;
        private IEmpleadosRepository _empleadosRepository;
        private IEpRepository _epRepository;
        private IFileRecordRepository _fileRecordRepository;
        private IFondosPensionRepository _fondosPensionRepository;
        private IServicioRepository _servicioRepository;
        private ITipoContratoRepository _tipoContratoRepository;

        public UnitofWork(SgeAdminContext context)
        {
            _context = context;
        }

        public ICargoRepository CargoRepository => _cargoRepository ??= new CargoRepository(_context);
        public IArlRepository ArlRepository => _arlRepository ??= new ArlRepository(_context);
        public ICecoRepository CecoRepository => _ccoRepository ??= new CecoRepository(_context);
        public IEmpleadosRepository EmpleadosRepository => _empleadosRepository ??= new EmpleadoRepository(_context);
        public IEpRepository EpRepository => _epRepository ??= new EpRepository(_context);
        public IFileRecordRepository FileRecordRepository => _fileRecordRepository ??= new FileRecordRepository(_context);
        public IFondosPensionRepository FondosPensionRepository => _fondosPensionRepository ??= new FondosPensionRepository(_context);
        public IServicioRepository ServicioRepository => _servicioRepository ??= new ServicioRepository(_context);
        public ITipoContratoRepository TipoContratoRepository => _tipoContratoRepository ??= new TiposContratoRepository(_context);

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
