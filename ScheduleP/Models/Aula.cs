using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleP.Models;

public partial class Aula
{
    public int IdAula { get; set; }

    [Required]
    public string? Nombre { get; set; }

    [Required]
    public int? Capacidad { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
}
