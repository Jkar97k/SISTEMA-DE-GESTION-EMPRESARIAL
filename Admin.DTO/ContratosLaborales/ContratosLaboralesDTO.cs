using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.DTO.ContratosLaborales
{
    public class ContratosLaboralesDTO
    {
        public int Id { get; set; }

        public int EmpleadoId { get; set; }

        public int ServicioId { get; set; }

        public int CargoId { get; set; }

        public decimal Salario { get; set; }

        public int Arlid { get; set; }

        public int FondoPensionId { get; set; }

        public int Epsid { get; set; }

        public int TipoContratoId { get; set; }

        public DateTime FechaIngreso { get; set; }

        public DateTime? FechaSalida { get; set; }

        public string HojaVidaRef { get; set; }

        public string SoportesRef { get; set; }
    }
}
