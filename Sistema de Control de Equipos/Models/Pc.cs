using System;
using System.Collections.Generic;

namespace Sistema_de_Control_de_Equipos.Models;

public partial class Pc
{
    public int Id { get; set; }

    public string Serial { get; set; } = null!;

    public int ResponsibleId { get; set; }

    public int DepartmentId { get; set; }

    public string Owner { get; set; } = null!;

    public string? Observations { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public virtual ICollection<Component> Components { get; set; } = new List<Component>();

    public virtual Department Department { get; set; } = null!;

    public virtual Responsible Responsible { get; set; } = null!;
}
