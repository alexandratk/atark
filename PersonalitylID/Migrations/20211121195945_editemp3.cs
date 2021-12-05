using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class editemp3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Group",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_TeacherId",
                table: "Group",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Teacher_TeacherId",
                table: "Group",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Teacher_TeacherId",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_TeacherId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Group");
        }
    }
}
