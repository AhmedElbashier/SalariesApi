using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalariesApi.Migrations
{
    /// <inheritdoc />
    public partial class _26th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeportationExpense",
                table: "PartialPayRolls",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HousingExpense",
                table: "PartialPayRolls",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LivingExpense",
                table: "PartialPayRolls",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StartingSalary",
                table: "PartialPayRolls",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeportationExpense",
                table: "PartialPayRolls");

            migrationBuilder.DropColumn(
                name: "HousingExpense",
                table: "PartialPayRolls");

            migrationBuilder.DropColumn(
                name: "LivingExpense",
                table: "PartialPayRolls");

            migrationBuilder.DropColumn(
                name: "StartingSalary",
                table: "PartialPayRolls");
        }
    }
}
