using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class addteacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PupilTeacher");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "PupilId",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_PupilId",
                table: "Teachers",
                column: "PupilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Pupils_PupilId",
                table: "Teachers",
                column: "PupilId",
                principalTable: "Pupils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Pupils_PupilId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_PupilId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "PupilId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Teachers");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PupilTeacher",
                columns: table => new
                {
                    PupilsId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PupilTeacher", x => new { x.PupilsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_PupilTeacher_Pupils_PupilsId",
                        column: x => x.PupilsId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PupilTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PupilTeacher_TeachersId",
                table: "PupilTeacher",
                column: "TeachersId");
        }
    }
}
