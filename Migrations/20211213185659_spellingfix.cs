using Microsoft.EntityFrameworkCore.Migrations;

namespace alien_api.Migrations
{
    public partial class spellingfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KardeshevRating",
                table: "Aliens");

            migrationBuilder.AddColumn<string>(
                name: "KardashevRating",
                table: "Aliens",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Aliens",
                keyColumn: "AlienId",
                keyValue: 1,
                column: "KardashevRating",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Aliens",
                keyColumn: "AlienId",
                keyValue: 2,
                column: "KardashevRating",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Aliens",
                keyColumn: "AlienId",
                keyValue: 3,
                column: "KardashevRating",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Aliens",
                keyColumn: "AlienId",
                keyValue: 4,
                column: "KardashevRating",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Aliens",
                keyColumn: "AlienId",
                keyValue: 5,
                column: "KardashevRating",
                value: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KardashevRating",
                table: "Aliens");

            migrationBuilder.AddColumn<int>(
                name: "KardeshevRating",
                table: "Aliens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Aliens",
                keyColumn: "AlienId",
                keyValue: 1,
                column: "KardeshevRating",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Aliens",
                keyColumn: "AlienId",
                keyValue: 2,
                column: "KardeshevRating",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Aliens",
                keyColumn: "AlienId",
                keyValue: 3,
                column: "KardeshevRating",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Aliens",
                keyColumn: "AlienId",
                keyValue: 4,
                column: "KardeshevRating",
                value: 2);
        }
    }
}
