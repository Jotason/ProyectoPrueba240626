using System.Net.Http.Json;
using FrontColegio.Models;

namespace FrontColegio.Services
{
    public class ProfesorService
    {
        private readonly HttpClient _http;

        public ProfesorService(HttpClient http)
        {
            _http = http;
        }

        // GET all (devuelve lista vacía si falla)
        public async Task<List<ProfesorDto>> GetProfesorsAsync()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<List<ProfesorDto>>("api/Profesors");
                return result ?? new List<ProfesorDto>(); // Evita nulo
            }
            catch
            {
                return new List<ProfesorDto>(); // En caso de error, lista vacía
            }
        }

        // GET by id (devuelve null si no encuentra o falla)
        public async Task<ProfesorDto?> GetProfesorAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<ProfesorDto>($"api/Profesors/{id}");
            }
            catch
            {
                return null;
            }
        }

        // POST (crear)
        public async Task<HttpResponseMessage> CreateProfesorAsync(ProfesorDto Profesor)
        {
            return await _http.PostAsJsonAsync("api/Profesors", Profesor);
        }

        // PUT (actualizar)
        public async Task<HttpResponseMessage> UpdateProfesorAsync(int id, ProfesorDto Profesor)
        {
            return await _http.PutAsJsonAsync($"api/Profesors/{id}", Profesor);
        }

        // DELETE
        public async Task<HttpResponseMessage> DeleteProfesorAsync(int id)
        {
            return await _http.DeleteAsync($"api/Profesors/{id}");
        }
    }
}