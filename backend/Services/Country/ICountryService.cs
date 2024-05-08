using System.Collections;

namespace Kinopoisk.Services.Country;

public interface ICountryService {
    Task<List<CountryDTO>> GetCountries();
    Task<CountryDTO> GetCountry(int id);
    Task<CountryDTO> AddCountry(CountryDTO countryDTO);
    Task<CountryDTO> UpdateCountry(CountryDTO countryDTO);
    Task<Hashtable> DeleteCountry(int id);
}