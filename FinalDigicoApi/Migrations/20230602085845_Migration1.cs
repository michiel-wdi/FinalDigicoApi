using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalDigicoApi.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
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
                    discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasicOccupationselfRef = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BasicOccupationselfRef1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.selfRef);
                    table.ForeignKey(
                        name: "FK_Skill_Occupations_BasicOccupationselfRef",
                        column: x => x.BasicOccupationselfRef,
                        principalTable: "Occupations",
                        principalColumn: "selfRef");
                    table.ForeignKey(
                        name: "FK_Skill_Occupations_BasicOccupationselfRef1",
                        column: x => x.BasicOccupationselfRef1,
                        principalTable: "Occupations",
                        principalColumn: "selfRef");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_BasicOccupationselfRef",
                table: "Skill",
                column: "BasicOccupationselfRef");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_BasicOccupationselfRef1",
                table: "Skill",
                column: "BasicOccupationselfRef1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Occupations");
        }
    }
}
