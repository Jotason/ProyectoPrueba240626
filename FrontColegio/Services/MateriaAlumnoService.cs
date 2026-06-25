using System.Net.Http.Json;
using FrontColegio.Models;

namespace FrontColegio.Services
{
    public class MateriaAlumnoService
    {
        private readonly HttpClient _http;

        public MateriaAlumnoService(HttpClient http) => _http = http;

        public async Task<List<MateriaAlumnoDto>> GetAsignacionesAsync()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<List<MateriaAlumnoDto>>("api/MateriaAlumno");
                return result ?? new List<MateriaAlumnoDto>();
            }
            catch
            {
                return new List<MateriaAlumnoDto>();
            }
        }

        public async Task<HttpResponseMessage> CreateAsignacionAsync(MateriaAlumnoDto dto)
        {
            return await _http.PostAsJsonAsync("api/MateriaAlumno", dto);
        }

        public async Task<HttpResponseMessage> DeleteAsignacionAsync(int id)
        {
            return await _http.DeleteAsync($"api/MateriaAlumno/{id}");
        }
    }
}