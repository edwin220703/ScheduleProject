using System;
using System.Collections.Generic;

namespace ScheduleP.Models;

public partial class Asignatura
{
    public int IdAsignatura { get; set; }

    public string? Nombre { get; set; }

    public int? HorasSemanales { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
}
