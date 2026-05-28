namespace TUP.MateriasMVC.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NombreCompleto => $"{Apellido}, {Nombre}";

        // Un alumno puede estar en muchas materias
        public ICollection<MateriaAlumno> MateriaAlumnos { get; set; } = new List<MateriaAlumno>();
    }
}
