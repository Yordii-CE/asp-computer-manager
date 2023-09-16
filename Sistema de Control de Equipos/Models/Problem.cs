using System;
using System.Collections.Generic;

namespace Sistema_de_Control_de_Equipos.Models;

public partial class Problem
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int PcId { get; set; }
}
