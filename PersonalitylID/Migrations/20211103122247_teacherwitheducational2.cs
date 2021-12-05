using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class teacherwitheducational2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_EducationalInstitution_EducationalInstitutionId",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationalInstitution",
                table: "EducationalInstitution");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "EducationalInstitution",
                newName: "EducationalInstitutions");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Teachers",
                newName: "Dateofbirth");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_EducationalInstitutionId",
                table: "Teachers",
                newName: "IX_Teachers_EducationalInstitutionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationalInstitutions",
                table: "EducationalInstitutions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_EducationalInstitutions_EducationalInstitutionId",
                table: "Teachers",
                column: "EducationalInstitutionId",
                principalTable: "EducationalInstitutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_EducationalInstitutions_EducationalInstitutionId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationalInstitutions",
                table: "EducationalInstitutions");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "EducationalInstitutions",
                newName: "EducationalInstitution");

            migrationBuilder.RenameColumn(
                name: "Dateofbirth",
                table: "Teacher",
                newName: "StartDate");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_EducationalInstitutionId",
                table: "Teacher",
                newName: "IX_Teacher_EducationalInstitutionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationalInstitution",
                table: "EducationalInstitution",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_EducationalInstitution_EducationalInstitutionId",
                table: "Teacher",
                column: "EducationalInstitutionId",
                principalTable: "EducationalInstitution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
