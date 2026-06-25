using System.ComponentModel.DataAnnotations;
namespace Colegio.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Identificacion { get; set; } = string.Empty; 
        [Required]
        public string Nombre { get; set; } = string.Empty; 
        [Required]
        public string Apellido { get; set; } = string.Empty; 
        public int Edad { get; set; } 
        public string Direccion { get; set; } = string.Empty; 
        public string Telefono { get; set; } = string.Empty; 

        
        public ICollection<MateriaAlumno> MateriasAsignadas { get; set; } = new List<MateriaAlumno>();
    }
}
