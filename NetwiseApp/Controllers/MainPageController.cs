using Microsoft.AspNetCore.Mvc;
using NetwiseApp.Dto;
using NetwiseApp.Services;

namespace NetwiseApp.Controllers
{
    [ApiController]
    [Route("api/facts")]
    public class MainPageController(ICatFactService catFactService, IFileService fileService) : ControllerBase
    {

        [HttpGet]
        public async Task<List<CatFactDto>> GetCatFacts()
        {
            List<CatFactDto> catFactsList = await fileService.GetFactsFromFile();
            return catFactsList;
        }

        [HttpPost]
        public async Task<IActionResult> NewCatFact()
        {
            CatFactDto? newFact = await catFactService.GetRandomFactAsync();
            if (newFact is null) return BadRequest();

            // Dodanie nowego faktu do pliku
            await fileService.AddFactToFile(newFact);

            return Ok(newFact);
        }
    }
}
