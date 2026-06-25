using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Colegio.Models;

namespace Colegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaAlumnoController : ControllerBase
    {
        private readonly ColegioDbContext _context;

        public MateriaAlumnoController(ColegioDbContext context)
        {
            _context = context;
        }

        // GET: api/MateriaAlumno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlumnoMateriaDto>>> GetMateriaAlumno()
        {
            var items = await _context.MateriasAlumnos
                .Include(am => am.Alumno)
                .Include(am => am.Materia)
                .Select(am => new AlumnoMateriaDto
                {
                    Id = am.Id,
                    AlumnoId = am.AlumnoId,
                    MateriaId = am.MateriaId,
                    AnioAcademico = am.AnioAcademico,
                    Calificacion = am.Calificacion,
                    NombreAlumno = am.Alumno != null ? $"{am.Alumno.Nombre} {am.Alumno.Apellido}" : null,
                    NombreMateria = am.Materia != null ? am.Materia.Nombre : null
                })
                .ToListAsync();

            return Ok(items);
        }

        // POST: api/MateriaAlumno
        [HttpPost]
        public async Task<ActionResult<AlumnoMateriaDto>> PostAlumnoMateria(AlumnoMateriaDto dto)
        {
            // Validar calificación en rango
            if (dto.Calificacion < 0 || dto.Calificacion > 5)
                return BadRequest("La calificación debe estar entre 0 y 5.");

            // Verificar duplicado
            var existe = await _context.MateriasAlumnos
                .AnyAsync(am => am.AlumnoId == dto.AlumnoId &&
                                am.MateriaId == dto.MateriaId &&
                                am.AnioAcademico == dto.AnioAcademico);
            if (existe)
                return Conflict("El alumno ya tiene esta materia asignada en el mismo año académico.");

            var entity = new MateriaAlumno
            {
                AlumnoId = dto.AlumnoId,
                MateriaId = dto.MateriaId,
                AnioAcademico = dto.AnioAcademico,
                Calificacion = dto.Calificacion
            };

            _context.MateriasAlumnos.Add(entity);
            await _context.SaveChangesAsync();

            // Devolver el DTO con el ID generado
            var resultDto = new AlumnoMateriaDto
            {
                Id = entity.Id,
                AlumnoId = entity.AlumnoId,
                MateriaId = entity.MateriaId,
                AnioAcademico = entity.AnioAcademico,
                Calificacion = entity.Calificacion
            };

            return CreatedAtAction(nameof(GetMateriaAlumno), new { id = entity.Id }, resultDto);
        }

        // DELETE: api/MateriaAlumno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumnoMateria(int id)
        {
            var item = await _context.MateriasAlumnos.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.MateriasAlumnos.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}