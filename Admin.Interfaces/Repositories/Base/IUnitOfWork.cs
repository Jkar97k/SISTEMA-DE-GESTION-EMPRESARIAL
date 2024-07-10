using Admin.Interfaces.Repositories.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Admin.Repositories.Base
{
    public interface IUnitofWork
    {
        IArlRepository ArlRepository { get; }
        ICargoRepository CargoRepository { get; }
        ICecoRepository CecoRepository { get; }
        IEmpleadosRepository EmpleadosRepository { get; }
        IEpRepository EpRepository { get; }
        IFileRecordRepository FileRecordRepository { get; }
        IFondosPensionRepository FondosPensionRepository { get; }
        IServicioRepository ServicioRepository { get; }
        ITipoContratoRepository TipoContratoRepository { get; }

        IDbContextTransaction BeginTransaction();
        void Dispose();
        Task SaveChanges();
    }
}