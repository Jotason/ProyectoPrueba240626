using Colegio.Models;
using Microsoft.EntityFrameworkCore;

namespace Colegio
{
    public class ColegioDbContext : DbContext
    {
        public ColegioDbContext(DbContextOptions<ColegioDbContext> options)
            : base(options)
        {
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores => Set<Profesor>();
        public DbSet<Materia> Materias => Set<Materia>();
        public DbSet<MateriaAlumno> MateriasAlumnos => Set<MateriaAlumno>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Un alumno no puede repetir materia el mismo año académico 
            // Índice único para evitar duplicados (mismo alumno, misma materia, mismo año)
            modelBuilder.Entity<MateriaAlumno>()
                .HasIndex(am => new { am.AlumnoId, am.MateriaId, am.AnioAcademico })
                .IsUnique()
                .HasDatabaseName("IX_MateriaAlumno_Unique");

            // Restricción de borrado en cascada: si se elimina un alumno, no se permite si tiene registros
            modelBuilder.Entity<MateriaAlumno>()
                .HasOne(am => am.Alumno)
                .WithMany(a => a.MateriaAlumnos)  
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MateriaAlumno>()
                .HasOne(am => am.Materia)
                .WithMany(m => m.MateriaAlumnos)  
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Materia>()

                .HasOne(m => m.Profesor)

                .WithMany(p => p.Materias)

                .HasForeignKey(m => m.ProfesorId)

                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }


    }
}
