using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Colegio.Models;

namespace Colegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly ColegioDbContext _context;

        public ReportesController(ColegioDbContext context)
        {
            _context = context;
        }

        [HttpGet("calificaciones")]
        public async Task<ActionResult<IEnumerable<ReporteCalificacionesDto>>> GetReporteCalificaciones()
        {
            var query = from am in _context.MateriasAlumnos
                        join a in _context.Alumnos on am.AlumnoId equals a.Id
                        join m in _context.Materias on am.MateriaId equals m.Id
                        join p in _context.Profesores on m.ProfesorId equals p.Id into profesorJoin
                        from p in profesorJoin.DefaultIfEmpty()
                        select new ReporteCalificacionesDto
                        {
                            AnioAcademico = am.AnioAcademico,
                            IdentificacionAlumno = a.Identificacion ?? string.Empty,
                            NombreAlumno = $"{a.Nombre} {a.Apellido}",
                            CodigoMateria = m.Codigo,
                            NombreMateria = m.Nombre,
                            IdentificacionProfesor = p != null ? p.Identificacion ?? string.Empty : string.Empty,
                            NombreProfesor = p != null ? $"{p.Nombre} {p.Apellido}" : "Sin asignar",
                            CalificacionFinal = am.Calificacion,
                            Aprobo = am.Calificacion >= 3.0m ? "SI" : "NO"
                        };

            var result = await query.ToListAsync();
            return Ok(result);
        }
    }
}