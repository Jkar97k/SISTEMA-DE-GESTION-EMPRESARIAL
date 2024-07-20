using Admin.Entities.Models;
using Admin.Interfaces;
using Admin.Repositories.Base;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Admin.Repositories.Repositories.Maestros
{
    public class EmpleadoRepository : Repository<Empleado, SgeAdminContext>, IEmpleadosRepository
    {
        public EmpleadoRepository(SgeAdminContext context, IMapper mapper) : base(context, mapper)
        {
            
        }
    }
}
