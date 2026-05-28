using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TUP.MateriasMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Dni = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Legajo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Anio = table.Column<int>(type: "INTEGER", nullable: false),
                    Cuatrimestre = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfesorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materias_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriaAlumnos",
                columns: table => new
                {
                    MateriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlumnoId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Condicion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaAlumnos", x => new { x.MateriaId, x.AlumnoId });
                    table.ForeignKey(
                        name: "FK_MateriaAlumnos_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriaAlumnos_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alumnos",
                columns: new[] { "Id", "Apellido", "Dni", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, "López", "40111222", "alopez@mail.com", "Agustín" },
                    { 2, "Martínez", "41222333", "bmartinez@mail.com", "Brenda" }
                });

            migrationBuilder.InsertData(
                table: "Profesores",
                columns: new[] { "Id", "Apellido", "Email", "Legajo", "Nombre" },
                values: new object[,]
                {
                    { 1, "Medina", "cmedina@tup.edu.ar", "P001", "Carlos" },
                    { 2, "Torres", "ltorres@tup.edu.ar", "P002", "Luciana" }
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "Anio", "Cuatrimestre", "Descripcion", "Nombre", "ProfesorId" },
                values: new object[,]
                {
                    { 1, 1, 1, "Intro a C#", "Programación I", 1 },
                    { 2, 1, 1, "POO práctica", "Laboratorio I", 2 }
                });

            migrationBuilder.InsertData(
                table: "MateriaAlumnos",
                columns: new[] { "AlumnoId", "MateriaId", "Condicion", "FechaInscripcion" },
                values: new object[,]
                {
                    { 1, 1, "Regular", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Libre", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, "Regular", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MateriaAlumnos_AlumnoId",
                table: "MateriaAlumnos",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_ProfesorId",
                table: "Materias",
                column: "ProfesorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaAlumnos");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
