using System.Collections;

namespace Kinopoisk.Services.Country;

public interface ICountryService {
    Task<List<CountryDTO>> GetCountries();
    Task<CountryDTO> GetCountry(string name);
    Task<CountryDTO> AddCountry(CountryDTO countryDTO);
    Task<CountryDTO> UpdateCountry(CountryDTO countryDTO);
    Task<Hashtable> DeleteCountry(string name);
}