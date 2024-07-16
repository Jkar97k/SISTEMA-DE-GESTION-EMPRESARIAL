using Admin.Interfaces;
using Admin.Repositories.Repositories;
using Admin.Repositories.Repositories.Maestros;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Admin.Entities.Models;

namespace Admin.Repositories.Base
{
    public class UnitofWork : IUnitofWork
    {
        private readonly SgeAdminContext _context;
        private readonly IMapper _mapper;
        private ICargoRepository _cargoRepository;
        private IArlRepository _arlRepository;
        private ICecoRepository _ccoRepository;
        private IEmpleadosRepository _empleadosRepository;
        private IContratosLaboraleRepository _contratosLaboraleRepository;
        private IEpRepository _epRepository;
        private IFileRecordRepository _fileRecordRepository;
        private IFondosPensionRepository _fondosPensionRepository;
        private IServicioRepository _servicioRepository;
        private ITipoContratoRepository _tipoContratoRepository;

        public UnitofWork(SgeAdminContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICargoRepository CargoRepository => _cargoRepository ??= new CargoRepository(_context, _mapper);
        public IArlRepository ArlRepository => _arlRepository ??= new ArlRepository(_context, _mapper);
        public ICecoRepository CecoRepository => _ccoRepository ??= new CecoRepository(_context, _mapper);
        public IEmpleadosRepository EmpleadosRepository => _empleadosRepository ??= new EmpleadoRepository(_context, _mapper);
        public IContratosLaboraleRepository ContratosLaboraleRepository => _contratosLaboraleRepository ??= new ContratosLaboraleRepository(_context, _mapper);
        public IEpRepository EpRepository => _epRepository ??= new EpRepository(_context, _mapper);
        public IFileRecordRepository FileRecordRepository => _fileRecordRepository ??= new FileRecordRepository(_context, _mapper);
        public IFondosPensionRepository FondosPensionRepository => _fondosPensionRepository ??= new FondosPensionRepository(_context, _mapper);
        public IServicioRepository ServicioRepository => _servicioRepository ??= new ServicioRepository(_context, _mapper);
        public ITipoContratoRepository TipoContratoRepository => _tipoContratoRepository ??= new TiposContratoRepository(_context, _mapper);

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
