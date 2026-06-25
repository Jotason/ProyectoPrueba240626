namespace FrontColegio.Models
{
    public class MateriaDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int ProfesorId { get; set; }
        // Opcional: para mostrar el nombre del profesor en la lista
        public string? NombreProfesor { get; set; }
    }
}
