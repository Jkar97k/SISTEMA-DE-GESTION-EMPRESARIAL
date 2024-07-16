using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.DTO
{
    public class RequestCreateEmpleado
    {
        public CreateEmpleadoDTO Empleado { get; set; }
        public CreateContratosLaboralesDTO ContratosLaborale { get; set; }
    }
}
