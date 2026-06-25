namespace FrontColegio.Models
{
    public class ReporteCalificacionesDto
    {
        public int AnioAcademico { get; set; }
        public string IdentificacionAlumno { get; set; } = string.Empty;
        public string NombreAlumno { get; set; } = string.Empty;
        public string CodigoMateria { get; set; } = string.Empty;
        public string NombreMateria { get; set; } = string.Empty;
        public string IdentificacionProfesor { get; set; } = string.Empty;
        public string NombreProfesor { get; set; } = string.Empty;
        public decimal CalificacionFinal { get; set; }
        public string Aprobo { get; set; } = string.Empty;
    }
}
