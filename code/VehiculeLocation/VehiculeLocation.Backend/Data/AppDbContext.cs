using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VehiculeLocation.Backend.Data.Seeding;
using VehiculeLocation.Backend.Models;

namespace VehiculeLocation.Backend.Data
{
    /// <summary>
    /// Gère la création et l'insertion des données
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicule> Vehicules { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Charge les configurateurs
            // Vehicule configurateur
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Application du Seeding
            // seeding vehicule
            modelBuilder.Entity<Vehicule>().HasData(VehiculeSeeder.GetVehiculeSeedData());
            // seeding location
            modelBuilder.Entity<Location>().HasData(LocationSeeder.GetLocationSeedData());

            // Relation des tables
            // Relation one to many de location
            modelBuilder.Entity<Vehicule>()
                .HasMany(v => v.Locations) // Un Vehicule a plusieurs Locations
                .WithOne(l => l.Vehicule)  // Chaque Location appartient à un Vehicule
                .HasForeignKey(l => l.VehiculeId) // Utilise VehiculeId comme clé étrangère
                .OnDelete(DeleteBehavior.Cascade); // Les locations sont supprimées si le véhicule l'est



        }
    }
}