using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class addlesson3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationalInstitutionId",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_EducationalInstitutionId",
                table: "Lesson",
                column: "EducationalInstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_EducationalInstitution_EducationalInstitutionId",
                table: "Lesson",
                column: "EducationalInstitutionId",
                principalTable: "EducationalInstitution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_EducationalInstitution_EducationalInstitutionId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_EducationalInstitutionId",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "EducationalInstitutionId",
                table: "Lesson");
        }
    }
}
