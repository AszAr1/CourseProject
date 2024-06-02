using System.Collections;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Kinopoisk.Services.MovieInfo;

public class MovieInfoService : IMovieInfoService {
    private readonly DataContext context;
    private IMapper mapper;
    private readonly IConfiguration configuration;

    public MovieInfoService(DataContext context, IMapper mapper, IConfiguration configuration) {
        this.context = context;
        this.mapper = mapper;
        this.configuration = configuration;
    }
    public async Task<GetMovieInfoDTO> CreateMovieInfo(CreateUpdateMovieInfoDTO createUpdateMovieInfoDTO) {
        var movieInfo = mapper.Map<MovieInfoModel>(createUpdateMovieInfoDTO);

        AddMovieGenres(createUpdateMovieInfoDTO, movieInfo);
        
        AddMovieCountries(createUpdateMovieInfoDTO, movieInfo);
        
        context.MovieInfos.Add(movieInfo);
        await context.SaveChangesAsync();
        return mapper.Map<GetMovieInfoDTO>(movieInfo);
    }
    public async Task<GetMovieInfoDTO> UpdateMovieInfo(CreateUpdateMovieInfoDTO createUpdateMovieInfoDTO) {
        var movieInfo = mapper.Map<MovieInfoModel>(createUpdateMovieInfoDTO);
        
        AddMovieGenres(createUpdateMovieInfoDTO, movieInfo);
        
        AddMovieCountries(createUpdateMovieInfoDTO, movieInfo);
        
        context.MovieInfos.Update(movieInfo);
        await context.SaveChangesAsync();
        return mapper.Map<GetMovieInfoDTO>(movieInfo);
    }
    private void AddMovieGenres(CreateUpdateMovieInfoDTO createUpdateMovieInfoDTO, MovieInfoModel movieInfo) {
        GenreModel? genre;
        foreach (Dictionary<string, string> keyValuePair in createUpdateMovieInfoDTO.DictGenres) {   
            genre = context.Genres.FirstOrDefault(g => g.Name == keyValuePair.Values.First());
            if (genre == null)
                throw new NullReferenceException($"Unknown genre: {keyValuePair.Values.First()}");

            if (context.MoviesGenres.FirstOrDefault(m => m.MovieInfoId == movieInfo.Id && m.GenreId == genre.Id) == null) {
                context.MoviesGenres.Add(
                    new MovieGenreModel{ 
                        Genre = genre, 
                        GenreId = genre.Id, 
                        MovieInfo = movieInfo, 
                        MovieInfoId = movieInfo.Id
                    }
                );
            }
        }
    }
    private void AddMovieCountries(CreateUpdateMovieInfoDTO createUpdateMovieInfoDTO, MovieInfoModel movieInfo) {
        CountryModel? country;
        foreach (Dictionary<string, string> keyValuePair in createUpdateMovieInfoDTO.DictCountries) {   
            country = context.Countries.FirstOrDefault(c => c.Name == keyValuePair.Values.First());
            if (country == null)
                throw new NullReferenceException($"Unknown country: {keyValuePair.Values.First()}");

            if (context.MoviesCountries.FirstOrDefault(m => m.MovieInfoId == movieInfo.Id && m.CountryId == country.Id) == null) {
                context.MoviesCountries.Add(
                    new MovieCountryModel{ 
                        Country = country, 
                        CountryId = country.Id, 
                        MovieInfo = movieInfo, 
                        MovieInfoId = movieInfo.Id
                    }
                );
            }
        }
    }
    public Task<Hashtable> DeleteMovieInfo(string name) {
        throw new NotImplementedException();
    }
    public async Task<GetMovieInfoDTO> GetMovieInfo(string name) {
        var movieInfo = await context.MovieInfos
            .Include(m => m.Genres)
            .Include(m => m.Countries)
            .FirstOrDefaultAsync(info => info.NameEn == name);
        return mapper.Map<GetMovieInfoDTO>(movieInfo);
    }
    public async Task<List<GetMovieInfoDTO>> GetMovieInfos() {
        var movieInfos = await context.MovieInfos.ToListAsync();
        return movieInfos.Select(mapper.Map<GetMovieInfoDTO>).ToList();
    }
    public async Task<List<GetStaffDTO>> GetStaff(string name) {
        var movieInfo = await context.MovieInfos.FirstOrDefaultAsync(info => info.NameEn == name);
        if (movieInfo == null) 
            throw new NullReferenceException($"Can't find movie info for movie: {name}");

        HttpClient client = new HttpClient();
        string url = $"https://kinopoiskapiunofficial.tech/api/v1/staff?filmId={movieInfo.KinopoiskId}";
        var request = new HttpRequestMessage {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };
        request.Headers.Add("X-API-KEY", configuration.GetSection("API_KEY").Value);

        HttpResponseMessage responseJson = await client.SendAsync(request);

        var json = await responseJson.Content.ReadAsStringAsync();    

        var staff = JsonConvert.DeserializeObject<List<GetStaffDTO>>(json);
        if (staff == null) 
            throw new NullReferenceException($"Could not find staff for film id: {movieInfo.KinopoiskId}");

        return staff;
    }
    public async Task<List<GetStaffDTO>> GetActors(string name) {
        List<GetStaffDTO> staff = await GetStaff(name);
        return staff.Where(s => s.ProfessionKey == StaffProffesion.ACTOR).ToList(); 
    }
    public async Task<List<GetStaffDTO>> GetDirectors(string name) {
        List<GetStaffDTO> staff = await GetStaff(name);
        return staff.Where(s => s.ProfessionKey == StaffProffesion.DIRECTOR).ToList(); 
    }
    public async Task<List<GetMovieInfoDTO>> Search(string searchString, int? page) {
        HttpClient client = new HttpClient();
        string stringPage = page == null ? "" : $"&page={page}";
        string url = $"https://kinopoiskapiunofficial.tech/api/v2.1/films/search-by-keyword?keyword={searchString}{stringPage}";
        var request = new HttpRequestMessage {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };
        request.Headers.Add("X-API-KEY", configuration.GetSection("API_KEY").Value);

        HttpResponseMessage response = await client.SendAsync(request);

        var json = await response.Content.ReadAsStringAsync();

        var movieData = JsonConvert.DeserializeObject<JsonSearchResponse>(json);
        Console.WriteLine(movieData);

        if (movieData == null) 
            throw new NullReferenceException("Could not get movie info");

        List<CreateUpdateMovieInfoDTO> createUpdateMovieInfoDTOs = movieData.Films;

        List<GetMovieInfoDTO> getMovieInfoDTOs = new();

        foreach (CreateUpdateMovieInfoDTO item in createUpdateMovieInfoDTOs) {
            if (context.MovieInfos.FirstOrDefault(info => info.KinopoiskId == item.KinopoiskId) == null) {
                getMovieInfoDTOs.Add(await CreateMovieInfo(item));
            } else {
                getMovieInfoDTOs.Add(await UpdateMovieInfo(item));
            }
        }

        return getMovieInfoDTOs;
    }
    public async Task<GetMovieInfoDTO> CreateWithKinopoiskID(int id) {
        HttpClient client = new HttpClient();
        string url = $"https://kinopoiskapiunofficial.tech/api/v2.2/films/{id}";
        var request = new HttpRequestMessage {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };
        request.Headers.Add("X-API-KEY", configuration.GetSection("API_KEY").Value);

        HttpResponseMessage responseJson = await client.SendAsync(request);

        var json = await responseJson.Content.ReadAsStringAsync();    
        var createMovieInfoDTO = JsonConvert.DeserializeObject<CreateUpdateMovieInfoDTO>(json);
        if (createMovieInfoDTO == null) 
            throw new NullReferenceException($"Can't find movie with kinopoisk id: {id}");

        var movieInfo = mapper.Map<MovieInfoModel>(createMovieInfoDTO);
        context.MovieInfos.Add(movieInfo);
        await context.SaveChangesAsync();

        return mapper.Map<GetMovieInfoDTO>(movieInfo);
    }
    public async Task<List<GetMovieInfoDTO>> Filter(FilterParameters parameters) {
        List<string> filters = new List<string>{
            parameters.Order == null ? "" : $"order={parameters.Order}",
            parameters.Type == null ? "" : $"type={parameters.Type}",
            parameters.RatingFrom == null ? "" : $"ratingFrom={parameters.RatingFrom}",
            parameters.RatingTo == null ? "" : $"ratingTo={parameters.RatingTo}",
            parameters.YearFrom == null ? "" : $"yearFrom={parameters.YearFrom}",
            parameters.YearTo == null ? "" : $"yearTo={parameters.YearTo}",
            parameters.Keyword == null ? "" : $"keyword={parameters.Keyword}",
            parameters.Page == null ? "" : $"page={parameters.Page}",
        };
        filters = filters.Where(x => x != "").ToList();
        var questionMark = filters.Count == 0 ? "" : "?";
        HttpClient client = new HttpClient();
        string url = $"https://kinopoiskapiunofficial.tech/api/v2.2/films{questionMark}{string.Join('&', filters)}";
        

        var request = new HttpRequestMessage {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };
        request.Headers.Add("X-API-KEY", configuration.GetSection("API_KEY").Value);


        HttpResponseMessage responseJson;
        try {
            responseJson = await client.SendAsync(request);
            
        }
        catch (System.Exception) {
            throw new HttpRequestException($"Unknown host: {url}");
        }


        var json = await responseJson.Content.ReadAsStringAsync();   

        var response = JsonConvert.DeserializeObject<JsonFilterResponse>(json);

        if (response == null) 
            throw new NullReferenceException($"can't serialize json string: {json}");

        List<GetMovieInfoDTO> getMovieInfoDTOs = new();

        foreach (CreateUpdateMovieInfoDTO item in response.Items) {
            if (context.MovieInfos.FirstOrDefault(info => info.KinopoiskId == item.KinopoiskId) == null) {
                getMovieInfoDTOs.Add(await CreateMovieInfo(item));
            } else {
                getMovieInfoDTOs.Add(await UpdateMovieInfo(item));
            }
        }

        return getMovieInfoDTOs;
    }

    public async Task<List<GetMovieInfoDTO>> GetTop(TopType type, int? page) {
        string stringType = Enum.GetName(typeof(TopType), type)!;
        string stringPage = page == null ? "" : $"&page={page}";

        HttpClient client = new HttpClient();
        string url = $"https://kinopoiskapiunofficial.tech/api/v2.2/films/collections?type={stringType}{stringPage}";

        var request = new HttpRequestMessage {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };
        request.Headers.Add("X-API-KEY", configuration.GetSection("API_KEY").Value);

        HttpResponseMessage responseJson = await client.SendAsync(request);

        var json = await responseJson.Content.ReadAsStringAsync();   

        var response = JsonConvert.DeserializeObject<JsonFilterResponse>(json);

        if (response == null) 
            throw new NullReferenceException($"couldn't deserialize json string: {json}");

        List<GetMovieInfoDTO> getMovieInfoDTOs = new();

        foreach (CreateUpdateMovieInfoDTO item in response.Items) 
            getMovieInfoDTOs.Add(await UpdateMovieInfo(item));

        return getMovieInfoDTOs;
    }
}