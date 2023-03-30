using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalariesApi.Migrations
{
    /// <inheritdoc />
    public partial class _25th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademicAllowance",
                table: "Partials",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AdministrativeAssignment",
                table: "Partials",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DegreeRoller",
                table: "Partials",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Partials",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Exp",
                table: "Partials",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Program",
                table: "Partials",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicAllowance",
                table: "Partials");

            migrationBuilder.DropColumn(
                name: "AdministrativeAssignment",
                table: "Partials");

            migrationBuilder.DropColumn(
                name: "DegreeRoller",
                table: "Partials");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Partials");

            migrationBuilder.DropColumn(
                name: "Exp",
                table: "Partials");

            migrationBuilder.DropColumn(
                name: "Program",
                table: "Partials");
        }
    }
}
