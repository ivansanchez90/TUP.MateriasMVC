using System.ComponentModel.DataAnnotations.Schema;

namespace TUP.MateriasMVC.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int Anio { get; set; }
        public int Cuatrimestre { get; set; }

        // Clave foránea → Profesor
        public int ProfesorId { get; set; }

        [ForeignKey(nameof(ProfesorId))]
        public Profesor? Profesor { get; set; }

        public ICollection<MateriaAlumno> MateriaAlumnos { get; set; } = new List<MateriaAlumno>();
    }
}
