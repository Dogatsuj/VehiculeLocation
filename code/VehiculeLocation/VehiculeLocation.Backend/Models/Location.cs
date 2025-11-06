using System;
using System.Text.Json.Serialization;

namespace VehiculeLocation.Backend.Models
{
    /// <summary>
    /// Location d'un véhicule a une data spécifique
    /// </summary>
    // Remarque: Si cette entité stocke également les informations du client, 
    // elle devrait être renommée "Reservation" comme dans nos échanges précédents.
    public class Location
    {
        // Clé primaire
        public int Id { get; set; }

        // Les dates de la période de location
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        // Clé étrangère pour lier à Vehicule
        public int VehiculeId { get; set; }

        // Propriété de navigation vers le véhicule (Utilisation de [JsonIgnore] si nécessaire)
        [JsonIgnore]
        public Vehicule? Vehicule { get; set; }
    }
}