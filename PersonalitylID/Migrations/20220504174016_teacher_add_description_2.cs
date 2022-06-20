using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class teacher_add_description_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Teacher");
        }
    }
}
