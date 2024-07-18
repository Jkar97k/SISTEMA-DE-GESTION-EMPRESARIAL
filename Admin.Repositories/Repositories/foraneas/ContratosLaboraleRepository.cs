using Admin.Entities.Models;
using Admin.Interfaces;
using Admin.Repositories.Base;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repositories
{
    public class ContratosLaboraleRepository : Repository<ContratosLaborale>, IContratosLaboraleRepository
    {
        private readonly SgeAdminContext _context;

        public ContratosLaboraleRepository(SgeAdminContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public async Task ActualizarRefContrato(int contentType, string nombre, string documento)
        {

            string column = contentType == 1 ? "HojaVidaRef" : "SoportesRef";

            string sql = $@"
            UPDATE ContratosLaborales C
            INNER JOIN Empleados E ON E.Id = C.EmpleadoId
            SET C.{column} = @nombre
            WHERE E.NumeroDocumento LIKE CONCAT(@documento, '%')";

            var nombreParam = new MySqlParameter("@nombre", nombre);
            var documentoParam = new MySqlParameter("@documento", documento);

            await _context.Database.ExecuteSqlRawAsync(sql, nombreParam, documentoParam);
        }
    }
}
