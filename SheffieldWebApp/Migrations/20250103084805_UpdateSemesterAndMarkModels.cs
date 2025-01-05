using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SheffieldWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSemesterAndMarkModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SemesterName",
                table: "Mark",
                newName: "SemesterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "Mark",
                newName: "SemesterName");
        }
    }
}
