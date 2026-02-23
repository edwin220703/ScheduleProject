using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ScheduleP.Models;

public partial class ScheduleDbContext : DbContext
{
    public ScheduleDbContext()
    {
    }

    public ScheduleDbContext(DbContextOptions<ScheduleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Aula> Aulas { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Edwin; Database=ScheduleDb; Trusted_Connection=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.IdAsignatura).HasName("PK__Asignatu__94F174B8F911E9C1");

            entity.ToTable("Asignatura");

            entity.HasIndex(e => e.Nombre, "UQ__Asignatu__75E3EFCF8FB4FD0A").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Aula>(entity =>
        {
            entity.HasKey(e => e.IdAula).HasName("PK__Aulas__2C89573C39755C95");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.IdDocente).HasName("PK__Docente__64A8726EF8227033");

            entity.ToTable("Docente");

            entity.Property(e => e.Especialidad).HasColumnType("text");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK__Grupos__303F6FD9F031F00D");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario).HasName("PK__Horarios__1539229B125E35B7");

            entity.Property(e => e.DiaSemana).HasMaxLength(50);
            entity.Property(e => e.HoraFin).HasColumnType("datetime");
            entity.Property(e => e.HoraInicio).HasColumnType("datetime");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdAsignatura)
                .HasConstraintName("FK_Horarios_Asignatura");

            entity.HasOne(d => d.IdAulaNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdAula)
                .HasConstraintName("FK_Horarios_Aulas");

            entity.HasOne(d => d.IdDocenteNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdDocente)
                .HasConstraintName("FK_Horarios_Docente");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("FK_Horarios_Grupos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
