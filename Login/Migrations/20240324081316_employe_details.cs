using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Login.Migrations
{
    /// <inheritdoc />
    public partial class employe_details : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeRole",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeRole",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Employees");
        }
    }
}
