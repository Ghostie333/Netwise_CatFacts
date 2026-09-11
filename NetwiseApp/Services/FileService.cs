using NetwiseApp.Dto;
using System.Text.Json;

namespace NetwiseApp.Services
{
    public class FileService : IFileService
    {
        private readonly string FileName = "catfacts.txt";
        public async Task AddFactToFile(CatFactDto catFactDto)
        {
            // Serializacja i zapis dto do pliku
            var json = JsonSerializer.Serialize(catFactDto);
            using var writer = new StreamWriter(FileName, append: true);
            await writer.WriteLineAsync(json);
        }

        public async Task<List<CatFactDto>> GetFactsFromFile()
        {
            if (!File.Exists(FileName)) return [];

            var list = new List<CatFactDto>();
            using var reader = new StreamReader(FileName);
            string? line;

            // Odczytanie pliku linia po linii, wyciąganie dto
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var dto = JsonSerializer.Deserialize<CatFactDto>(line);
                if (dto is not null) list.Add(dto);
            }

            return list;
        }
    }
}
