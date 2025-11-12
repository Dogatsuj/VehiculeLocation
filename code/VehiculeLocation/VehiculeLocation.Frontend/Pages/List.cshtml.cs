using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VehiculeLocation.Frontend.Models;

namespace VehiculeLocation.Frontend.Pages
{
    public class ListModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public ListModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("ApiBackend");

                var response = await client.GetAsync("api/Vehicle");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    Vehicles = JsonSerializer.Deserialize<List<Vehicle>>(content, options) ?? new List<Vehicle>();
                }
                else
                {
                    Console.WriteLine($"API Call failed: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}