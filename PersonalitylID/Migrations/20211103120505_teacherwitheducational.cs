using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class teacherwitheducational : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationalInstitutionId",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_EducationalInstitutionId",
                table: "Teacher",
                column: "EducationalInstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_EducationalInstitution_EducationalInstitutionId",
                table: "Teacher",
                column: "EducationalInstitutionId",
                principalTable: "EducationalInstitution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_EducationalInstitution_EducationalInstitutionId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_EducationalInstitutionId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "EducationalInstitutionId",
                table: "Teacher");
        }
    }
}
