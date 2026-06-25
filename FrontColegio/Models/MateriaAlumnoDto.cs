namespace FrontColegio.Models
{
    public class MateriaAlumnoDto
    {
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public int MateriaId { get; set; }
        public int AnioAcademico { get; set; }
        public decimal Calificacion { get; set; }
        public string? NombreAlumno { get; set; }
        public string? NombreMateria { get; set; }
    }
}
