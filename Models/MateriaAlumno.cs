namespace TUP.MateriasMVC.Models
{
    public class MateriaAlumno
    {
        public int MateriaId { get; set; }
        public Materia Materia { get; set; } = null!;

        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; } = null!;

        public DateTime FechaInscripcion { get; set; } = DateTime.Now;
        public string? Condicion { get; set; } // Regular, Libre, Promocionado
    }
}
