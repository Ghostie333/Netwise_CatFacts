using NetwiseApp.Dto;

namespace NetwiseApp.Services
{
    public interface ICatFactService
    {
        Task<CatFactDto?> GetRandomFactAsync();
    }
}
