using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DTO
{
    public record CreateUsuarioDTO(
        string NumeroDocumento,
        string Correo,
        string Contrasenna,
        int Role,
        string CodigoValidacion,
        DateTime ExpiracionCodigo,
        DateTime? FechaDesactivacion,
       bool Status 
    );
}
