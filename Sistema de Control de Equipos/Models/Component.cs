using System;
using System.Collections.Generic;

namespace Sistema_de_Control_de_Equipos.Models;

public partial class Component
{
    public int Id { get; set; }

    public string Serial { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Specification { get; set; }

    public int BrandId { get; set; }

    public int ModelId { get; set; }

    public int PcId { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Model Model { get; set; } = null!;

    public virtual Pc Pc { get; set; } = null!;
}
