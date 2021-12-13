using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace alien_api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aliens",
                columns: table => new
                {
                    AlienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    OriginPlanet = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    OriginSystem = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    NumberOfPlanets = table.Column<int>(type: "int", nullable: false),
                    BreathesOxygen = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    KardeshevRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliens", x => x.AlienId);
                });

            migrationBuilder.InsertData(
                table: "Aliens",
                columns: new[] { "AlienId", "BreathesOxygen", "Description", "KardeshevRating", "Name", "NumberOfPlanets", "OriginPlanet", "OriginSystem" },
                values: new object[,]
                {
                    { 1, true, "A warlike lizardlike species", 1, "Turians", 123, "Palaven", "Palaven" },
                    { 2, false, "A species of short, grey skinned aliens that enjoys experimenting on other lifeforms", 2, "Greys", 10, "Glarikiblak", "Falzor" },
                    { 3, true, "An Warlike race of alien clones on a galactic Conquest", 3, "Irken", 200, "Irken", "Kelbo" },
                    { 4, false, "A race of sentient Machines created by the Greys", 2, "Tivbots", 14, "Glarikiblak", "Falzor" },
                    { 5, true, "A warlike species of of hairless monkeys", 0, "Humans", 1, "Earth", "Sol" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aliens");
        }
    }
}
