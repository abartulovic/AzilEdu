using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AzilEdu.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAnimalStatusRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Species = table.Column<string>(type: "TEXT", nullable: false),
                    Breed = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    AnimalStatusId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_AnimalStatuses_AnimalStatusId",
                        column: x => x.AnimalStatusId,
                        principalTable: "AnimalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AnimalStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dostupna za udomljenje" },
                    { 2, "Rezervirana" },
                    { 3, "Udomljena" },
                    { 4, "Na liječenju" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "AnimalStatusId", "ArrivalDate", "Breed", "Description", "Gender", "ImageUrl", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 3, 1, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mješanac", "Mirna i druželjubiva kujica.", "Ženka", "/images/animals/luna.webp", "Luna", "Pas" },
                    { 2, 5, 2, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Labrador", "Aktivan pas koji voli šetnje.", "Mužjak", "/images/animals/rex.webp", "Rex", "Pas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalStatusId",
                table: "Animals",
                column: "AnimalStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "AnimalStatuses");
        }
    }
}
