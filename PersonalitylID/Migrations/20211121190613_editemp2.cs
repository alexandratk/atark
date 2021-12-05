using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class editemp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupPupil");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Pupil",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pupil_GroupId",
                table: "Pupil",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pupil_Group_GroupId",
                table: "Pupil",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pupil_Group_GroupId",
                table: "Pupil");

            migrationBuilder.DropIndex(
                name: "IX_Pupil_GroupId",
                table: "Pupil");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Pupil");

            migrationBuilder.CreateTable(
                name: "GroupPupil",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    PupilsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPupil", x => new { x.GroupsId, x.PupilsId });
                    table.ForeignKey(
                        name: "FK_GroupPupil_Group_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupPupil_Pupil_PupilsId",
                        column: x => x.PupilsId,
                        principalTable: "Pupil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupPupil_PupilsId",
                table: "GroupPupil",
                column: "PupilsId");
        }
    }
}
