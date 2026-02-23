using System;
using System.Collections.Generic;

namespace ScheduleP.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    public int? IdDocente { get; set; }

    public int? IdAsignatura { get; set; }

    public int? IdAula { get; set; }

    public int? IdGrupo { get; set; }

    public string? DiaSemana { get; set; }

    public DateTime? HoraInicio { get; set; }

    public DateTime? HoraFin { get; set; }

    public virtual Asignatura? IdAsignaturaNavigation { get; set; }

    public virtual Aula? IdAulaNavigation { get; set; }

    public virtual Docente? IdDocenteNavigation { get; set; }

    public virtual Grupo? IdGrupoNavigation { get; set; }
}
