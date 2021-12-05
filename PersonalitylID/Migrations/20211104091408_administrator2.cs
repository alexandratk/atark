using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class administrator2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dateofbirth",
                table: "Administrator");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Administrator",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Administrator",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Administrator");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Administrator");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dateofbirth",
                table: "Administrator",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
