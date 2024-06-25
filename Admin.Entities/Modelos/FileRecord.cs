﻿using System;
using System.Collections.Generic;

namespace Admin.Entities.Modelos;

public partial class FileRecord
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string ContentType { get; set; } = null!;

    public byte[]? FileLocation { get; set; }

    public string Ruta { get; set; } = null!;

    public string Guid { get; set; } = null!;
}
