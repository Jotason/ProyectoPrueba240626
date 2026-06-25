

using System.ComponentModel.DataAnnotations;
namespace Colegio.Models
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; } = string.Empty;
        [Required]
        public string Nombre { get; set; } = string.Empty;

        public int? ProfesorId { get; set; }
        public Profesor? Profesor { get; set; }
    }
}