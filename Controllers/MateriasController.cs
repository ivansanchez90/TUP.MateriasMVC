using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TUP.MateriasMVC.Data;

namespace TUP.MateriasMVC.Controllers
{
    public class MateriasController : Controller
    {
        private readonly AppDbContext _db;

        public MateriasController(AppDbContext db)
        {
            _db = db;  // EF Core se inyecta automáticamente
        }

        // GET /Materias → listado
        public async Task<IActionResult> Index()
        {
            var materias = await _db.Materias
                .Include(m => m.Profesor)          // JOIN con Profesores
                .Include(m => m.MateriaAlumnos)    // para contar alumnos
                .OrderBy(m => m.Anio)
                .ToListAsync();

            return View(materias);
        }

        // GET /Materias/Detalle/5 → detalle con alumnos
        public async Task<IActionResult> Detalle(int id)
        {
            var materia = await _db.Materias
                .Include(m => m.Profesor)
                .Include(m => m.MateriaAlumnos)
                    .ThenInclude(ma => ma.Alumno)  // JOIN anidado
                .FirstOrDefaultAsync(m => m.Id == id);

            if (materia is null) return NotFound();

            return View(materia);
        }
    }
}
