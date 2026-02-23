using System;
using System.Collections.Generic;

namespace ScheduleP.Models;

public partial class Docente
{
    public int IdDocente { get; set; }

    public string? Nombre { get; set; }

    public string? Especialidad { get; set; }

    public int? HorasMaximas { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
}
