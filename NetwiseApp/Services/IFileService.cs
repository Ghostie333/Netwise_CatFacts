using NetwiseApp.Dto;

namespace NetwiseApp.Services
{
    public interface IFileService
    {
        public Task AddFactToFile(CatFactDto catFactDto);
        public Task<List<CatFactDto>> GetFactsFromFile();
    }
}
