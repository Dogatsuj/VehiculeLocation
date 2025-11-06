using System.Text.Json.Serialization;

namespace VehiculeLocation.Frontend.Models
{
    /// <summary>
    /// Location d'un véhicule a une data spécifique
    /// </summary>

    public class Location
    {
        public int Id { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

    }
}