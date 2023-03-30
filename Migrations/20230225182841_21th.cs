using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalariesApi.Migrations
{
    /// <inheritdoc />
    public partial class _21th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpId",
                table: "Absences",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Absences");
        }
    }
}
