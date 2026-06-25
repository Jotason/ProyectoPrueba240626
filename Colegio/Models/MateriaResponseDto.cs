namespace Colegio.Models
{
    public class MateriaResponseDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int? ProfesorId { get; set; }
        public string? NombreProfesor { get; set; } 
    }
}
