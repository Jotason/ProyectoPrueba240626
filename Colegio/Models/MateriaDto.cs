namespace Colegio.Models
{
    public class MateriaDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int? ProfesorId { get; set; }
    }
}
