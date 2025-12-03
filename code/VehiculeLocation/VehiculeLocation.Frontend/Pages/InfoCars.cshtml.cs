using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VehiculeLocation.Frontend.Models;

namespace VehiculeLocation.Frontend.Pages
{
    public class InfoCarsModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Vehicle? Vehicle { get; set; }

        // Propriétés pour le formulaire de réservation
        [BindProperty]
        public string? dateStart { get; set; }

        [BindProperty]
        public string? dateEnd { get; set; }

        [BindProperty]
        public int vehicleId { get; set; }

        public InfoCarsModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Méthode pour appeler l'API de réservation
        public async Task BookAsync(string dateStart, string dateEnd, int vehicleId)
        {
            var client = _httpClientFactory.CreateClient("ApiBackend");

            var body = new
            {
                dateStart = dateStart,
                dateEnd = dateEnd
            };

            var content = new StringContent(
                JsonSerializer.Serialize(body),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await client.PutAsync($"api/Vehicle/{vehicleId}/locations", content);

            if (!response.IsSuccessStatusCode)
            {
                // Optionnel : log ou gestion d'erreur
                Console.WriteLine($"Booking failed: {response.StatusCode}");
            }
        }

        // Handler pour le formulaire POST
        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(dateStart) || string.IsNullOrEmpty(dateEnd))
            {
                ModelState.AddModelError(string.Empty, "Please select start and end dates.");
                return Page();
            }

            await BookAsync(dateStart, dateEnd, vehicleId);

            // Redirection après réservation réussie
            return RedirectToPage("/Confirmation"); // Crée une page Confirmation si besoin
        }

        // Handler GET pour charger les détails du véhicule
        public async Task<IActionResult> OnGetAsync()
        {
            Console.WriteLine($"InfoCars - Requested ID: {Id}");

            try
            {
                var client = _httpClientFactory.CreateClient("ApiBackend");

                Console.WriteLine($"Calling API: api/Vehicle/{Id}");
                var response = await client.GetAsync($"api/Vehicle/{Id}");

                Console.WriteLine($"API Response Status: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Content: {content}");

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    Vehicle = JsonSerializer.Deserialize<Vehicle>(content, options);

                    if (Vehicle == null)
                    {
                        Console.WriteLine("Vehicle is null after deserialization");
                        return NotFound();
                    }

                    Console.WriteLine($"Vehicle loaded: {Vehicle.Brand} {Vehicle.Model}");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return NotFound();
                }
                else
                {
                    Console.WriteLine($"API Call failed: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }

            return Page();
        }
    }
}
