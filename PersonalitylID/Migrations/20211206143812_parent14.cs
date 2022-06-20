using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class parent14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EducInstId",
                table: "Parent",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EducInstId",
                table: "Parent");
        }
    }
}
