using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class addteacher3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Pupils_PupilId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_PupilId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "PupilId",
                table: "Teacher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PupilId",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_PupilId",
                table: "Teacher",
                column: "PupilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Pupils_PupilId",
                table: "Teacher",
                column: "PupilId",
                principalTable: "Pupils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
