using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class addteacher2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Pupils_PupilId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_PupilId",
                table: "Teacher",
                newName: "IX_Teacher_PupilId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Pupils_PupilId",
                table: "Teacher",
                column: "PupilId",
                principalTable: "Pupils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Pupils_PupilId",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_PupilId",
                table: "Teachers",
                newName: "IX_Teachers_PupilId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Pupils_PupilId",
                table: "Teachers",
                column: "PupilId",
                principalTable: "Pupils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
