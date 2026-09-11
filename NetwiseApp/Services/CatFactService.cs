using NetwiseApp.Dto;

namespace NetwiseApp.Services
{
    public class CatFactService(HttpClient http) : ICatFactService
    {
        public async Task<CatFactDto?> GetRandomFactAsync()
        {
            return await http.GetFromJsonAsync<CatFactDto>("fact");
        }
    }
}