using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class auth2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Teacher",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Pupil",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Pupil",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Parent",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Parent",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Employee",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Administrator",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Administrator",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Teacher");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Pupil",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Pupil");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Parent",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Parent");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Administrator",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Administrator");
        }
    }
}
