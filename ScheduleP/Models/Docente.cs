using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleP.Models;

public partial class Docente
{
    public int IdDocente { get; set; }

    [Required]
    public string? Nombre { get; set; }

    [Required]
    public string? Especialidad { get; set; }

    [Required]
    public int? HorasMaximas { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
}
