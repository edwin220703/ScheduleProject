CREATE DATABASE ScheduleDb


Create Table Docente(
	IdDocente int primary key identity,
	Nombre nvarchar(50),
	Especialidad text,
	HorasMaximas int
);

Create table Asignatura(
	IdAsignatura int primary key identity,
	Nombre nvarchar(50) unique,
	HorasSemanales int
);

Create table Aulas(
	IdAula int primary key identity,
	Nombre nvarchar(50),
	Capacidad int
);

Create table Grupos(
	IdGrupo int primary key identity,
	Nombre nvarchar(50),
	NivelEducativo int,
);

Create table Horarios(
	IdHorario int primary key identity,
	IdDocente int,
	IdAsignatura int,
	IdAula int,
	IdGrupo int,
	DiaSemana nvarchar(50),
	HoraInicio Datetime,
	HoraFin datetime
);