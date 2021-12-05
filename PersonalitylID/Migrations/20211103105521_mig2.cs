using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pupils_Notebooks_NotebookId",
                table: "Pupils");

            migrationBuilder.DropTable(
                name: "Notebooks");

            migrationBuilder.DropIndex(
                name: "IX_Pupils_NotebookId",
                table: "Pupils");

            migrationBuilder.DropColumn(
                name: "NotebookId",
                table: "Pupils");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotebookId",
                table: "Pupils",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notebooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebooks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pupils_NotebookId",
                table: "Pupils",
                column: "NotebookId",
                unique: true,
                filter: "[NotebookId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Pupils_Notebooks_NotebookId",
                table: "Pupils",
                column: "NotebookId",
                principalTable: "Notebooks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
