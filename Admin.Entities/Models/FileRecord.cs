using System;
using System.Collections.Generic;

namespace Admin.Entities.Models;

public partial class FileRecord
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string ContentType { get; set; }

    public byte[] File { get; set; }

    public string Ruta { get; set; }

    public string Guid { get; set; }
}
