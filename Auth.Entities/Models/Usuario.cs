using System;
using System.Collections.Generic;

namespace Auth.Entities.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasenna { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string CodigoValidacion { get; set; } = null!;

    public DateTime ExpiracionCodigo { get; set; }

    public DateTime? FechaDesactivacion { get; set; }
}
