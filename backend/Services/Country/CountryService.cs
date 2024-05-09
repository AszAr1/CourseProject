using System.Collections;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Kinopoisk.Services.Country;

public class CountryService : ICountryService {
    private readonly IMapper mapper;
    private readonly DataContext context;
    public CountryService(IMapper m, DataContext c) {   
        mapper = m;
        context = c;
    }
    public async Task<CountryDTO> AddCountry(CountryDTO countryDTO)
    {
        context.Countries.Add(mapper.Map<CountryModel>(countryDTO));
        await context.SaveChangesAsync();
        return countryDTO;
    }

    public async Task<Hashtable> DeleteCountry(string name) {
        var countries = await context.Countries.ToListAsync();
        context.Countries.Remove(countries.Find(c => c.Name == name)!);
        await context.SaveChangesAsync();
        return new Hashtable {
            { "message", $"Movie with name {name} was deleted" },
            { "status", 200 },
        };
    }

    public async Task<List<CountryDTO>> GetCountries() {
        var countries = await context.Countries.ToListAsync();
        return countries.Select(mapper.Map<CountryDTO>).ToList();
    }

    public async Task<CountryDTO> GetCountry(string name) {
        var countries = await context.Countries.ToListAsync();
        return mapper.Map<CountryDTO>(countries.FirstOrDefault(c => c.Name == name));
    }

    public Task<CountryDTO> UpdateCountry(CountryDTO countryDTO)
    {
        throw new NotImplementedException();
    }
}