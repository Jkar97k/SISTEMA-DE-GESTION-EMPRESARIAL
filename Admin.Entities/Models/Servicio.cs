using System;
using System.Collections.Generic;

namespace Admin.Entities.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public int Cecoid { get; set; }
}
