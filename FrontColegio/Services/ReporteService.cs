using System.Net.Http.Json;
using FrontColegio.Models;

namespace FrontColegio.Services
{
    public class ReporteService
    {
        private readonly HttpClient _http;

        public ReporteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ReporteCalificacionesDto>> GetReporteCalificacionesAsync()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<List<ReporteCalificacionesDto>>("api/Reportes/calificaciones");
                return result ?? new List<ReporteCalificacionesDto>();
            }
            catch
            {
                return new List<ReporteCalificacionesDto>();
            }
        }
    }
}