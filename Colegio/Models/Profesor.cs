
using System.ComponentModel.DataAnnotations;
namespace Colegio.Models
{
    public class Profesor
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
        public ICollection<Materia> Materias { get; set; } = new List<Materia>();
    }
}
