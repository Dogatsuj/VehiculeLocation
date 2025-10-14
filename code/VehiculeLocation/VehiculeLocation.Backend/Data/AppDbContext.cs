using Microsoft.EntityFrameworkCore;
using VehiculeLocation.Backend.Models;

namespace VehiculeLocation.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Ajoutez vos DbSet pour chaque entité que vous voulez dans la BDD
        public DbSet<Vehicule> Vehicules { get; set; } = null!;

        // --- Méthode de Seeding ---
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicule>().HasData(
                new Vehicule { Id = 1, Modele = "Renault Clio V", Place = 5 },
                new Vehicule { Id = 2, Modele = "Peugeot 3008", Place = 5 },
                new Vehicule { Id = 3, Modele = "Renault Twingo", Place = 5 },
                new Vehicule { Id = 4, Modele = "Citroën C3", Place = 5 }
            );
        }
    }
}
