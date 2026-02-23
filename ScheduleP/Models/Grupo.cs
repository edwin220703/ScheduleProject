using System;
using System.Collections.Generic;

namespace ScheduleP.Models;

public partial class Grupo
{
    public int IdGrupo { get; set; }

    public string? Nombre { get; set; }

    public int? NivelEducativo { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
}
