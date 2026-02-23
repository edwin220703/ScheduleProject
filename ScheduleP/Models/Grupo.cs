using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleP.Models;

public partial class Grupo
{
    public int IdGrupo { get; set; }

    [Required]
    public string? Nombre { get; set; }

    [Required]
    public int? NivelEducativo { get; set; }

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
}
