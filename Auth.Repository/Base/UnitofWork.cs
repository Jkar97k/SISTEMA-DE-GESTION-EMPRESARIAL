using Auth.Entities.Models;
using Auth.Interfaces;
using Auth.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;

namespace Auth.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly SgeAuthContext _context;
        private readonly IMapper _mapper;
        private IUsuarioRepository _usuarioRepository;


        public UnitofWork(SgeAuthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUsuarioRepository UsuarioRepository => _usuarioRepository ??= new UsuarioRepository(_context, _mapper);


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
