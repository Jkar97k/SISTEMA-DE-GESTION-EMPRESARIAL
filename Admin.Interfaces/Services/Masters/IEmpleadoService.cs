using Admin.DTO.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Interfaces.Services.Masters
{
    public interface IEmpleadoService
    {
        Task Create(CreateEmpleadoDTO dto);
    }
}
