using FrontColegio.Models;

namespace FrontColegio.Services
{
    public class MateriaService
    {
        private readonly HttpClient _http;

        public MateriaService(HttpClient http) => _http = http;

        public async Task<List<MateriaDto>> GetMateriasAsync()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<List<MateriaDto>>("api/Materias");
                return result ?? new List<MateriaDto>();
            }
            catch
            {
                return new List<MateriaDto>();
            }
        }

        public async Task<MateriaDto?> GetMateriaAsync(int id)
        {
            try
            {
                return await _http.GetFromJsonAsync<MateriaDto>($"api/Materias/{id}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> CreateMateriaAsync(MateriaDto materia)
        {
            return await _http.PostAsJsonAsync("api/Materias", materia);
        }

        public async Task<HttpResponseMessage> UpdateMateriaAsync(int id, MateriaDto materia)
        {
            return await _http.PutAsJsonAsync($"api/Materias/{id}", materia);
        }

        public async Task<HttpResponseMessage> DeleteMateriaAsync(int id)
        {
            return await _http.DeleteAsync($"api/Materias/{id}");
        }
    }
}
