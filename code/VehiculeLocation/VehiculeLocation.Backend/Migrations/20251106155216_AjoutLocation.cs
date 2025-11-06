using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehiculeLocation.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AjoutLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Vehicules",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VehiculeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Vehicules_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "DateEnd", "DateStart", "VehiculeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 13, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2025, 12, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2025, 12, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2025, 12, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_VehiculeId",
                table: "Locations",
                column: "VehiculeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Vehicules",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
