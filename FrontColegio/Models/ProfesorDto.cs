namespace FrontColegio.Models
{
    public class ProfesorDto
    {

        public int Id { get; set; }
        public string Identificacion { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
    }
}
