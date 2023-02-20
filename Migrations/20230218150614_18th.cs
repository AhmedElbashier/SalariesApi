using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalariesApi.Migrations
{
    /// <inheritdoc />
    public partial class _18th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstMonthPayRoll",
                table: "PackagePayRolls");

            migrationBuilder.DropColumn(
                name: "SecondMonthPayRoll",
                table: "PackagePayRolls");

            migrationBuilder.DropColumn(
                name: "ThirdMonthPayRoll",
                table: "PackagePayRolls");

            migrationBuilder.AddColumn<string>(
                name: "FirstMonthPayRoll",
                table: "Packages",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SecondMonthPayRoll",
                table: "Packages",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ThirdMonthPayRoll",
                table: "Packages",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstMonthPayRoll",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "SecondMonthPayRoll",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ThirdMonthPayRoll",
                table: "Packages");

            migrationBuilder.AddColumn<string>(
                name: "FirstMonthPayRoll",
                table: "PackagePayRolls",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SecondMonthPayRoll",
                table: "PackagePayRolls",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ThirdMonthPayRoll",
                table: "PackagePayRolls",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
