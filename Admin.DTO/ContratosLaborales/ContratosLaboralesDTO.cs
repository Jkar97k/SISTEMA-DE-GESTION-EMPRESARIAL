using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.DTO.ContratosLaborales
{
    public record ContratosLaboralesDTO(
        int Id,
        int EmpleadoId,
        int ServicioId,
        int CargoId,
        decimal Salario,
        int Arlid,
        int FondoPensionId,
        int Epsid,
        int TipoContratoId,
        DateTime FechaIngreso,
        DateTime? FechaSalida,
        string HojaVidaRef,
        string SoportesRef
        );
}
