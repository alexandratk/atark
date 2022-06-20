using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class parent15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EducInstId",
                table: "Parent",
                newName: "EducationalInstitutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EducationalInstitutionId",
                table: "Parent",
                newName: "EducInstId");
        }
    }
}
