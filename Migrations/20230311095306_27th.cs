using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalariesApi.Migrations
{
    /// <inheritdoc />
    public partial class _27th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Advances",
                newName: "PeriodLeft");

            migrationBuilder.AddColumn<string>(
                name: "Credit",
                table: "Advances",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Debit",
                table: "Advances",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EmpId",
                table: "Advances",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EmpName",
                table: "Advances",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credit",
                table: "Advances");

            migrationBuilder.DropColumn(
                name: "Debit",
                table: "Advances");

            migrationBuilder.DropColumn(
                name: "EmpId",
                table: "Advances");

            migrationBuilder.DropColumn(
                name: "EmpName",
                table: "Advances");

            migrationBuilder.RenameColumn(
                name: "PeriodLeft",
                table: "Advances",
                newName: "Name");
        }
    }
}
