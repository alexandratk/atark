using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalitylID.Migrations
{
    public partial class administrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pupils_SchoolClasses_SchoolClassId",
                table: "Pupils");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_EducationalInstitutions_EducationalInstitutionId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolClasses",
                table: "SchoolClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pupils",
                table: "Pupils");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationalInstitutions",
                table: "EducationalInstitutions");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "SchoolClasses",
                newName: "SchoolClass");

            migrationBuilder.RenameTable(
                name: "Pupils",
                newName: "Pupil");

            migrationBuilder.RenameTable(
                name: "EducationalInstitutions",
                newName: "EducationalInstitution");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_EducationalInstitutionId",
                table: "Teacher",
                newName: "IX_Teacher_EducationalInstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Pupils_SchoolClassId",
                table: "Pupil",
                newName: "IX_Pupil_SchoolClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolClass",
                table: "SchoolClass",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pupil",
                table: "Pupil",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationalInstitution",
                table: "EducationalInstitution",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dateofbirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EducationalInstitutionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrator_EducationalInstitution_EducationalInstitutionId",
                        column: x => x.EducationalInstitutionId,
                        principalTable: "EducationalInstitution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrator_EducationalInstitutionId",
                table: "Administrator",
                column: "EducationalInstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pupil_SchoolClass_SchoolClassId",
                table: "Pupil",
                column: "SchoolClassId",
                principalTable: "SchoolClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Pupil_SchoolClass_SchoolClassId",
                table: "Pupil");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_EducationalInstitution_EducationalInstitutionId",
                table: "Teacher");

            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolClass",
                table: "SchoolClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pupil",
                table: "Pupil");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EducationalInstitution",
                table: "EducationalInstitution");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "SchoolClass",
                newName: "SchoolClasses");

            migrationBuilder.RenameTable(
                name: "Pupil",
                newName: "Pupils");

            migrationBuilder.RenameTable(
                name: "EducationalInstitution",
                newName: "EducationalInstitutions");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_EducationalInstitutionId",
                table: "Teachers",
                newName: "IX_Teachers_EducationalInstitutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Pupil_SchoolClassId",
                table: "Pupils",
                newName: "IX_Pupils_SchoolClassId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolClasses",
                table: "SchoolClasses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pupils",
                table: "Pupils",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EducationalInstitutions",
                table: "EducationalInstitutions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pupils_SchoolClasses_SchoolClassId",
                table: "Pupils",
                column: "SchoolClassId",
                principalTable: "SchoolClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_EducationalInstitutions_EducationalInstitutionId",
                table: "Teachers",
                column: "EducationalInstitutionId",
                principalTable: "EducationalInstitutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
