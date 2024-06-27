using Admin.Interfaces.Repositories.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Admin.Repositories.Base
{
    public interface IUnitofWork
    {
        ICargoRepository CargoRepository { get; }

        IDbContextTransaction BeginTransaction();
        Task SaveChanges();
        void Dispose();
    }
}