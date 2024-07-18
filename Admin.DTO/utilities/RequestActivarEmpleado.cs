using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.DTO.utilities
{
    public record RequestActivarEmpleado(
        string IdenficadorEmpleado,
        string Correo,
        int Cargo
        );
}
