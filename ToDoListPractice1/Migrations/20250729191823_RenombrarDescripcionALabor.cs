using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListPractice1.Migrations
{
    /// <inheritdoc />
    public partial class RenombrarDescripcionALabor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Tareas",
                newName: "Labor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Labor",
                table: "Tareas",
                newName: "Nombre");
        }
    }
}
