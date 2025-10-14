using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehiculeLocation.Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedVehicules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicules",
                columns: new[] { "Id", "Modele", "Place" },
                values: new object[,]
                {
                    { 1, "Renault Clio V", 5 },
                    { 2, "Peugeot 3008", 5 },
                    { 3, "Renault Twingo", 5 },
                    { 4, "Citroën C3", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicules",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
