using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalDigicoApi.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    selfRef = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.selfRef);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    selfRef = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.selfRef);
                });

            migrationBuilder.CreateTable(
                name: "occationBasicSkills",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsEssential = table.Column<bool>(type: "bit", nullable: false),
                    skillselfRef = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BasicOccupationselfRef = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_occationBasicSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_occationBasicSkills_Occupations_BasicOccupationselfRef",
                        column: x => x.BasicOccupationselfRef,
                        principalTable: "Occupations",
                        principalColumn: "selfRef");
                    table.ForeignKey(
                        name: "FK_occationBasicSkills_Skill_skillselfRef",
                        column: x => x.skillselfRef,
                        principalTable: "Skill",
                        principalColumn: "selfRef");
                });

            migrationBuilder.CreateIndex(
                name: "IX_occationBasicSkills_BasicOccupationselfRef",
                table: "occationBasicSkills",
                column: "BasicOccupationselfRef");

            migrationBuilder.CreateIndex(
                name: "IX_occationBasicSkills_skillselfRef",
                table: "occationBasicSkills",
                column: "skillselfRef");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "occationBasicSkills");

            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropTable(
                name: "Skill");
        }
    }
}
