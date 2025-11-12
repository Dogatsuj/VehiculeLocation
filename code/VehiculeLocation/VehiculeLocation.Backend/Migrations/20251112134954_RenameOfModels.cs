using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehiculeLocation.Backend.Migrations
{
    /// <inheritdoc />
    public partial class RenameOfModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Place",
                table: "Vehicules",
                newName: "Seats");

            migrationBuilder.RenameColumn(
                name: "Modele",
                table: "Vehicules",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "DailyLocationPrice",
                table: "Vehicules",
                newName: "DailyRentalPrice");

            migrationBuilder.RenameColumn(
                name: "AutomaticTransmission",
                table: "Vehicules",
                newName: "IsAutomaticTransmission");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Vehicules",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Vehicules",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Vehicules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Brand", "Description", "ImagePath", "Model" },
                values: new object[] { "Renault", "Une voiture qui roule", "https://upload.wikimedia.org/wikipedia/commons/6/6d/Dunkerque-1.jpg", "Clio V" });

            migrationBuilder.UpdateData(
                table: "Vehicules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Brand", "Description", "ImagePath", "Model" },
                values: new object[] { "Peugeot", "Une voiture qui roule", "https://upload.wikimedia.org/wikipedia/commons/6/6d/Dunkerque-1.jpg", "3008" });

            migrationBuilder.UpdateData(
                table: "Vehicules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "Description", "ImagePath", "Model" },
                values: new object[] { "Renault", "Une voiture qui roule", "https://upload.wikimedia.org/wikipedia/commons/6/6d/Dunkerque-1.jpg", "Twingo" });

            migrationBuilder.UpdateData(
                table: "Vehicules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Brand", "Description", "ImagePath", "Model" },
                values: new object[] { "Citroën", "Une voiture qui roule", "https://upload.wikimedia.org/wikipedia/commons/6/6d/Dunkerque-1.jpg", "C3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Vehicules");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Vehicules");

            migrationBuilder.RenameColumn(
                name: "Seats",
                table: "Vehicules",
                newName: "Place");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Vehicules",
                newName: "Modele");

            migrationBuilder.RenameColumn(
                name: "IsAutomaticTransmission",
                table: "Vehicules",
                newName: "AutomaticTransmission");

            migrationBuilder.RenameColumn(
                name: "DailyRentalPrice",
                table: "Vehicules",
                newName: "DailyLocationPrice");

            migrationBuilder.UpdateData(
                table: "Vehicules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImagePath", "Modele" },
                values: new object[] { "https://lh6.googleusercontent.com/proxy/HEmJ7BvDYuo0uaBAecqWSianL5MBS7XzuqV7Nu-scTwvXRipC-hl4cd9crmQyWRGlpVFfhzCUNeDJr5najGvzJgFieuCF71nqwFxy22zmJpFOaGjHaieImL9dQCHvliO5n5Z8AgF83m7qs4ntaPlLsE", "Renault Clio V" });

            migrationBuilder.UpdateData(
                table: "Vehicules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImagePath", "Modele" },
                values: new object[] { "https://lh6.googleusercontent.com/proxy/HEmJ7BvDYuo0uaBAecqWSianL5MBS7XzuqV7Nu-scTwvXRipC-hl4cd9crmQyWRGlpVFfhzCUNeDJr5najGvzJgFieuCF71nqwFxy22zmJpFOaGjHaieImL9dQCHvliO5n5Z8AgF83m7qs4ntaPlLsE", "Peugeot 3008" });

            migrationBuilder.UpdateData(
                table: "Vehicules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImagePath", "Modele" },
                values: new object[] { "https://lh6.googleusercontent.com/proxy/HEmJ7BvDYuo0uaBAecqWSianL5MBS7XzuqV7Nu-scTwvXRipC-hl4cd9crmQyWRGlpVFfhzCUNeDJr5najGvzJgFieuCF71nqwFxy22zmJpFOaGjHaieImL9dQCHvliO5n5Z8AgF83m7qs4ntaPlLsE", "Renault Twingo" });

            migrationBuilder.UpdateData(
                table: "Vehicules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImagePath", "Modele" },
                values: new object[] { "https://lh6.googleusercontent.com/proxy/HEmJ7BvDYuo0uaBAecqWSianL5MBS7XzuqV7Nu-scTwvXRipC-hl4cd9crmQyWRGlpVFfhzCUNeDJr5najGvzJgFieuCF71nqwFxy22zmJpFOaGjHaieImL9dQCHvliO5n5Z8AgF83m7qs4ntaPlLsE", "Citroën C3" });
        }
    }
}
