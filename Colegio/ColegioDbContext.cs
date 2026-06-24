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

        // Opcional: configuraciones adicionales con OnModelCreating
    }
}
