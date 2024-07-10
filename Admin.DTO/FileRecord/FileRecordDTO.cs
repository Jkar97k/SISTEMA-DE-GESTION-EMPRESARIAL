using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.DTO.FileRecord
{
    public class FileRecordDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string ContentType { get; set; } = null!;

        public byte[]? FileLocation { get; set; }

        public string Ruta { get; set; } = null!;

        public string Guid { get; set; } = null!;
    }
}
