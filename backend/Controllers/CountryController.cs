using Microsoft.AspNetCore.Mvc;

namespace Kinopoisk.Controllers;

[ApiController]
[Route("countries")]
public class CountryController : ControllerBase {
    private readonly ICountryService countryService;
    public CountryController(ICountryService cS) {
        countryService = cS;
    }

    [HttpGet]
    public async Task<ActionResult<List<CountryDTO>>> Index() => 
        Ok(await countryService.GetCountries());

    [HttpGet("{name}")]
    public async Task<ActionResult<CountryDTO>> Get(string name) => 
        Ok(await countryService.GetCountry(name));

    [HttpPost("create")]
    public async Task<ActionResult<CountryDTO>> Create(CountryDTO countryDTO) => 
        Ok(await countryService.AddCountry(countryDTO));
}