using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DatosEnvioCorreoDTO
    {
        public string Asunto { get; set; }
        public string ContenidoHTML { get; set; }
        public string CorreoRemitente { get; set; }
        public string NombreRemitente { get; set; }
        public string CorreoDestinatario { get; set; }
        public string NombreDestinatario { get; set; }
    }
}
