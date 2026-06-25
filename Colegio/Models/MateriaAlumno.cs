
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Colegio.Models
{
    public class MateriaAlumno
    {
        [Key]
        public int Id { get; set; }

        public int AlumnoId { get; set; }
        [ForeignKey(nameof(AlumnoId))]
        public Alumno? Alumno { get; set; }

        public int MateriaId { get; set; }
        [ForeignKey(nameof(MateriaId))]
        public Materia? Materia { get; set; }

        [Required]
        public int AnioAcademico { get; set; }

        [Range(0, 5, ErrorMessage = "La calificación debe estar entre 0 y 5.")]
        public decimal Calificacion { get; set; }
    }
}
