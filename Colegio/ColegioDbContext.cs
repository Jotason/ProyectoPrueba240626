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
        // Restricción: Un alumno no puede repetir materia el mismo año académico 
            modelBuilder.Entity<MateriaAlumno>()
                .HasIndex(ma => new { ma.AnioAcademico, ma.AlumnoId, ma.MateriaId })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

       
    }
}
