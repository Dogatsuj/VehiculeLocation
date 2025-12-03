using System.Text.Json.Serialization;

namespace VehiculeLocation.Backend.Models
{
    /// <summary>
    /// Utilisateur du site
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}