using System;
using System.Collections.Generic;

namespace Admin.Entities.Modelos;

public partial class FondosPensione
{
    public int Id { get; set; }

    public string Nombre { get; set; } 

    public virtual ICollection<ContratosLaborale> ContratosLaborales { get; set; } = new List<ContratosLaborale>();
}
