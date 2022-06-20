using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class parent16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EducationalInstitutionId",
                table: "Parent",
                newName: "EducInstId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EducInstId",
                table: "Parent",
                newName: "EducationalInstitutionId");
        }
    }
}
