using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.DTO
{
    public class FileRecordDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string ContentType { get; set; }

        public byte[]? FileLocation { get; set; }

        public string Ruta { get; set; } 

        public string Guid { get; set; }
    }
}
