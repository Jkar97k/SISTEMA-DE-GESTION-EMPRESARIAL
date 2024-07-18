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

            var contratosLaborales = _context.ContratosLaborales
                .Include(c => c.Empleado)
                .Where(c => c.Empleado.NumeroDocumento.StartsWith(documento));

            foreach (var contrato in contratosLaborales)
            {
                if (column == "HojaVidaRef")
                {
                    contrato.HojaVidaRef = nombre;
                }
                else if (column == "SoportesRef")
                {
                    contrato.SoportesRef = nombre;
                }
            }

            await _context.SaveChangesAsync();
        }

    }
}
