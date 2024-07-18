using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.DTO
{
    public record CreateEmpleadoDTO(
        int id,
        int TipoDocumento,
        string NumeroDocumento,
        string Nombres,
        string Apellidos,
        string CorreoPersonal,
        string CorreoEmpresarial,
        string Direccion,
        long Telefono,
        long ContactoEmergencia,
        long TelefonoContactoEmergencia,
        string Guid,
        DateTime Created,
        string ModifiedBy,
        DateTime ModifiedDate,
        bool Status
        );
}
