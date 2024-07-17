﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.DTO
{
    public class CreateFileRecordDTO
    {
        public string IdentificadorEmpleado { get; set; }

        public string Nombre { get; set; }

        public int ContentType { get; set; }

        public byte[] File { get; set; }

        public string Ruta { get; set; }

        public string Guid { get; set; }
    }
}
