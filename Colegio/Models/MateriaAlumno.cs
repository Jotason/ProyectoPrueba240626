
using System.ComponentModel.DataAnnotations;
namespace Colegio.Models
{
    public class MateriaAlumno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AnioAcademico { get; set; }

        [Required]
        public int AlumnoId { get; set; }
        public Alumno? Alumno { get; set; }

        [Required]
        public int MateriaId { get; set; }
        public Materia? Materia { get; set; }


        [Range(0.0, 5.0)]
        public decimal CalificacionFinal { get; set; }
    }
}
