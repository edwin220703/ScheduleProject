using System;
using System.Collections.Generic;

namespace ScheduleP.Models;

public partial class Aula
{
    public int IdAula { get; set; }

    public string? Nombre { get; set; }

    public int? Capacidad { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
}
