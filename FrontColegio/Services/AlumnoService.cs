using System.Net.Http.Json;
using FrontColegio.Models;

namespace FrontColegio.Services
{
    public class AlumnoService
    {
        private readonly HttpClient _http;

        public AlumnoService(HttpClient http)
        {
            _http = http;
        }

        // GET all (devuelve lista vacía si falla)
        public async Task<List<AlumnoDto>> GetAlumnosAsync()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<List<AlumnoDto>>("api/Alumnoes");
                return result ?? new List<AlumnoDto>(); // Evita nulo
            }
            catch
            {
                return new List<AlumnoDto>(); // En caso de error, lista vacía
            }
        }

        // GET by id (devuelve null si no encuentra o falla)
        public async Task<AlumnoDto?> GetAlumnoAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<AlumnoDto>($"api/Alumnoes/{id}");
            }
            catch
            {
                return null;
            }
        }

        // POST (crear)
        public async Task<HttpResponseMessage> CreateAlumnoAsync(AlumnoDto alumno)
        {
            return await _http.PostAsJsonAsync("api/Alumnoes", alumno);
        }

        // PUT (actualizar)
        public async Task<HttpResponseMessage> UpdateAlumnoAsync(int id, AlumnoDto alumno)
        {
            return await _http.PutAsJsonAsync($"api/Alumnoes/{id}", alumno);
        }

        // DELETE
        public async Task<HttpResponseMessage> DeleteAlumnoAsync(int id)
        {
            return await _http.DeleteAsync($"api/Alumnoes/{id}");
        }
    }
}