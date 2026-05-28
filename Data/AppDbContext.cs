using Microsoft.EntityFrameworkCore;
using TUP.MateriasMVC.Models;

namespace TUP.MateriasMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Cada DbSet = una tabla en la BD
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaAlumno> MateriaAlumnos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Clave compuesta para la tabla intermedia
            modelBuilder.Entity<MateriaAlumno>()
                .HasKey(ma => new { ma.MateriaId, ma.AlumnoId });

            // Relaciones muchos-a-muchos
            modelBuilder.Entity<MateriaAlumno>()
                .HasOne(ma => ma.Materia)
                .WithMany(m => m.MateriaAlumnos)
                .HasForeignKey(ma => ma.MateriaId);

            modelBuilder.Entity<MateriaAlumno>()
                .HasOne(ma => ma.Alumno)
                .WithMany(a => a.MateriaAlumnos)
                .HasForeignKey(ma => ma.AlumnoId);

            // Datos iniciales (Seed Data)
            modelBuilder.Entity<Profesor>().HasData(
                new Profesor { Id = 1, Nombre = "Carlos", Apellido = "Medina", Email = "cmedina@tup.edu.ar", Legajo = "P001" },
                new Profesor { Id = 2, Nombre = "Luciana", Apellido = "Torres", Email = "ltorres@tup.edu.ar", Legajo = "P002" }
            );

            modelBuilder.Entity<Alumno>().HasData(
                new Alumno { Id = 1, Nombre = "Agustín", Apellido = "López", Dni = "40111222", Email = "alopez@mail.com" },
                new Alumno { Id = 2, Nombre = "Brenda", Apellido = "Martínez", Dni = "41222333", Email = "bmartinez@mail.com" }
            );

            modelBuilder.Entity<Materia>().HasData(
                new Materia { Id = 1, Nombre = "Programación I", Descripcion = "Intro a C#", Anio = 1, Cuatrimestre = 1, ProfesorId = 1 },
                new Materia { Id = 2, Nombre = "Laboratorio I", Descripcion = "POO práctica", Anio = 1, Cuatrimestre = 1, ProfesorId = 2 }
            );

            var fecha = new DateTime(2024, 3, 1);
            modelBuilder.Entity<MateriaAlumno>().HasData(
                new MateriaAlumno { MateriaId = 1, AlumnoId = 1, FechaInscripcion = fecha, Condicion = "Regular" },
                new MateriaAlumno { MateriaId = 1, AlumnoId = 2, FechaInscripcion = fecha, Condicion = "Libre" },
                new MateriaAlumno { MateriaId = 2, AlumnoId = 1, FechaInscripcion = fecha, Condicion = "Regular" }
            );
        }
    }
}
