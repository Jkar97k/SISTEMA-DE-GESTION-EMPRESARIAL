using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.DTO
{
    public class CreateFileRecord
    {
        public string Bucket { get; set; }

        public string Nombre { get; set; }

        public string ContentType { get; set; }

        public string Guid { get; set; }
    }
}
