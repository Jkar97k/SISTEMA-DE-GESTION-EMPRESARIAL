
using Admin.Interfaces;
using Admin.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore.Storage;

namespace Admin.Interfaces
{
    public interface IUnitofWork
    {
        IArlRepository ArlRepository { get; }
        ICargoRepository CargoRepository { get; }
        ICecoRepository CecoRepository { get; }
        IEmpleadosRepository EmpleadosRepository { get; }
        IContratosLaboraleRepository ContratosLaboraleRepository { get; }
        IEpRepository EpRepository { get; }
        IFileRecordRepository FileRecordRepository { get; }
        IFondosPensionRepository FondosPensionRepository { get; }
        IServicioRepository ServicioRepository { get; }
        ITipoContratoRepository TipoContratoRepository { get; }
        IBacklLogsRepository BacklLogsRepository { get; }

        IDbContextTransaction BeginTransaction();
        void Dispose();
        Task SaveChanges();
    }
}