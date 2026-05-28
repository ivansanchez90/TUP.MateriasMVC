namespace TUP.MateriasMVC.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Legajo { get; set; } = string.Empty;
        public string NombreCompleto => $"{Apellido}, {Nombre}";

        // Un profesor tiene muchas materias
        public ICollection<Materia> Materias { get; set; } = new List<Materia>();
    }
}
