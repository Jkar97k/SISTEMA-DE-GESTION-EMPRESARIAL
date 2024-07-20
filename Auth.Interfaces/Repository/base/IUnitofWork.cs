using Auth.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Auth.Interfaces
{
    public interface IUnitofWork
    {
        IUsuarioRepository UsuarioRepository { get; }

        IDbContextTransaction BeginTransaction();
        void Dispose();
        Task SaveChanges();
    }
}