using System.Text;
using System.Text.Json;
using JhoelSuarezPruebaProg2.Models;
namespace JhoelSuarezPruebaProg2.Services
{
    public class PersonaService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7293/api/Personas"; // Asegúrate de que la API está corriendo
        public PersonaService()
        {
            _httpClient = new HttpClient();
        }
        // Enviar una persona a la API
        public async Task<bool> AgregarPersona(Persona persona)
        {
            var json = JsonSerializer.Serialize(persona);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(BaseUrl, content);
            return response.IsSuccessStatusCode;
        }
        // Obtener todas las personas desde la API
        public async Task<List<Persona>> ObtenerPersonas()
        {
            try
            {
                var response = await _httpClient.GetAsync(BaseUrl);
                if (!response.IsSuccessStatusCode)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "No se pudieron obtener los datos de la API.", "OK");
                    return new List<Persona>();
                }
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Persona>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Problema al conectar con la API: {ex.Message}", "OK");
                return new List<Persona>();
            }
        }
    }
}