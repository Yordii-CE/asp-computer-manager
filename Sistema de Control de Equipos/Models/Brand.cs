using System;
using System.Collections.Generic;

namespace Sistema_de_Control_de_Equipos.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Component> Components { get; set; } = new List<Component>();
}
