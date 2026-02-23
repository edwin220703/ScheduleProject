using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleP.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    [Required]
    public int? IdDocente { get; set; }

    [Required]
    public int? IdAsignatura { get; set; }

    [Required]
    public int? IdAula { get; set; }

    [Required]
    public int? IdGrupo { get; set; }

    [Required]
    public string? DiaSemana { get; set; }

    [Required]
    public DateTime? HoraInicio { get; set; }

    [Required]
    public DateTime? HoraFin { get; set; }

    public virtual Asignatura? IdAsignaturaNavigation { get; set; }

    public virtual Aula? IdAulaNavigation { get; set; }

    public virtual Docente? IdDocenteNavigation { get; set; }

    public virtual Grupo? IdGrupoNavigation { get; set; }
}
