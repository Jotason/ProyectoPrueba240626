using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Colegio;
using Colegio.Models;

namespace Colegio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaAlumnoesController : ControllerBase
    {
        private readonly ColegioDbContext _context;

        public MateriaAlumnoesController(ColegioDbContext context)
        {
            _context = context;
        }

        // GET: api/MateriaAlumnoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MateriaAlumno>>> GetMateriasAlumnos()
        {
            return await _context.MateriasAlumnos.ToListAsync();
        }

        // GET: api/MateriaAlumnoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MateriaAlumno>> GetMateriaAlumno(int id)
        {
            var materiaAlumno = await _context.MateriasAlumnos.FindAsync(id);

            if (materiaAlumno == null)
            {
                return NotFound();
            }

            return materiaAlumno;
        }

        // PUT: api/MateriaAlumnoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateriaAlumno(int id, MateriaAlumno materiaAlumno)
        {
            if (id != materiaAlumno.Id)
            {
                return BadRequest();
            }

            _context.Entry(materiaAlumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaAlumnoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MateriaAlumnoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MateriaAlumno>> PostMateriaAlumno(MateriaAlumno materiaAlumno)
        {
            _context.MateriasAlumnos.Add(materiaAlumno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMateriaAlumno", new { id = materiaAlumno.Id }, materiaAlumno);
        }

        // DELETE: api/MateriaAlumnoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateriaAlumno(int id)
        {
            var materiaAlumno = await _context.MateriasAlumnos.FindAsync(id);
            if (materiaAlumno == null)
            {
                return NotFound();
            }

            _context.MateriasAlumnos.Remove(materiaAlumno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriaAlumnoExists(int id)
        {
            return _context.MateriasAlumnos.Any(e => e.Id == id);
        }
    }
}
