using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class addlesson4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_EducationalInstitution_EducationalInstitutionId",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_EducationalInstitutionId",
                table: "Lesson");

            migrationBuilder.AlterColumn<int>(
                name: "EducationalInstitutionId",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EducationalInstitutionId",
                table: "Lesson",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
