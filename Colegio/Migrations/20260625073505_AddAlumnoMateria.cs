using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Colegio.Migrations
{
    /// <inheritdoc />
    public partial class AddAlumnoMateria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Profesores_ProfesorId",
                table: "Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriasAlumnos_Alumnos_AlumnoId",
                table: "MateriasAlumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriasAlumnos_Materias_MateriaId",
                table: "MateriasAlumnos");

            migrationBuilder.DropIndex(
                name: "IX_MateriasAlumnos_AlumnoId",
                table: "MateriasAlumnos");

            migrationBuilder.DropIndex(
                name: "IX_MateriasAlumnos_AnioAcademico_AlumnoId_MateriaId",
                table: "MateriasAlumnos");

            migrationBuilder.RenameColumn(
                name: "CalificacionFinal",
                table: "MateriasAlumnos",
                newName: "Calificacion");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaAlumno_Unique",
                table: "MateriasAlumnos",
                columns: new[] { "AlumnoId", "MateriaId", "AnioAcademico" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Profesores_ProfesorId",
                table: "Materias",
                column: "ProfesorId",
                principalTable: "Profesores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasAlumnos_Alumnos_AlumnoId",
                table: "MateriasAlumnos",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasAlumnos_Materias_MateriaId",
                table: "MateriasAlumnos",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Profesores_ProfesorId",
                table: "Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriasAlumnos_Alumnos_AlumnoId",
                table: "MateriasAlumnos");

            migrationBuilder.DropForeignKey(
                name: "FK_MateriasAlumnos_Materias_MateriaId",
                table: "MateriasAlumnos");

            migrationBuilder.DropIndex(
                name: "IX_MateriaAlumno_Unique",
                table: "MateriasAlumnos");

            migrationBuilder.RenameColumn(
                name: "Calificacion",
                table: "MateriasAlumnos",
                newName: "CalificacionFinal");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasAlumnos_AlumnoId",
                table: "MateriasAlumnos",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasAlumnos_AnioAcademico_AlumnoId_MateriaId",
                table: "MateriasAlumnos",
                columns: new[] { "AnioAcademico", "AlumnoId", "MateriaId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Profesores_ProfesorId",
                table: "Materias",
                column: "ProfesorId",
                principalTable: "Profesores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasAlumnos_Alumnos_AlumnoId",
                table: "MateriasAlumnos",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MateriasAlumnos_Materias_MateriaId",
                table: "MateriasAlumnos",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
