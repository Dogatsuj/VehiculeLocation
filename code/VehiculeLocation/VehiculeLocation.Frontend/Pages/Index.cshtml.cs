// MonProjet.WebClient/Pages/Index.cshtml.cs

using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VehiculeLocation.Frontend.Models; // Utilisez le modèle de véhicule du front-end

namespace VehiculeLocation.Frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // La liste pour stocker les données récupérées
        public List<Vehicule> Vehicules { get; set; } = new List<Vehicule>();

        // Injection du HttpClientFactory configuré dans Program.cs
        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            try
            {
                // Récupération du client configuré pour l'API
                var client = _httpClientFactory.CreateClient("ApiBackend");

                // Appel de l'endpoint API: GET https://localhost:7001/api/Vehicule
                var response = await client.GetAsync("api/Vehicule");

                if (response.IsSuccessStatusCode)
                {
                    // Lecture et désérialisation du JSON
                    var content = await response.Content.ReadAsStringAsync();

                    // Options de désérialisation (pour gérer les noms de propriétés)
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    Vehicules = JsonSerializer.Deserialize<List<Vehicule>>(content, options) ?? new List<Vehicule>();
                }
                else
                {
                    // Gérer l'échec de l'appel API (par exemple, logger l'erreur)
                    Console.WriteLine($"API Call failed: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Gérer les erreurs de connexion/réseau
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}