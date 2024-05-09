using System.Collections;
using Newtonsoft.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Kinopoisk.Services.Movie;


public class MovieService : IMovieService {
    private readonly IMapper mapper;
    private readonly DataContext context;
    private readonly IConfiguration configuration;

    public MovieService(IMapper m, DataContext c, IConfiguration config) {
        mapper = m;
        context = c;
        configuration = config;
    }
    public async Task<GetMovieDTO> AddMovie(CreateMovieDTO createMovieDTO)
    {
        MovieModel movie = mapper.Map<MovieModel>(createMovieDTO);

        var movieFile = createMovieDTO.File;

        if (movieFile == null) 
            throw new ArgumentException("Could get movie file");

        string filePath = Path.Join(MovieModel.BASE_PATH, createMovieDTO.File?.FileName);

        using (FileStream fileStream = new FileStream(filePath, FileMode.Create)) {
            await movieFile.CopyToAsync(fileStream);
        }

        var fileURI = new Uri(MovieModel.BASE_URI + filePath);

        movie.Uri = fileURI.ToString();
        
        HttpClient client = new HttpClient();
        string url = $"https://kinopoiskapiunofficial.tech/api/v2.1/films/search-by-keyword?keyword={createMovieDTO.Name}&page=1";

        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };
        request.Headers.Add("X-API-KEY", configuration.GetSection("API_KEY").Value);

        HttpResponseMessage responseJson = await client.SendAsync(request);

        var json = await responseJson.Content.ReadAsStringAsync();
        var movieData = JsonConvert.DeserializeObject<JsonResponse>(json);
        Console.WriteLine(movieData);

        if (movieData == null) 
            throw new NullReferenceException("Counld get movie info");

        CreateMovieInfoDTO createMovieInfoDTO = movieData.Films[0];
        
        MovieInfoModel movieInfo = mapper.Map<MovieInfoModel>(createMovieInfoDTO);
        movieInfo.Movie = movie;
        movie.MovieInfoId = movieInfo.Id;
        movie.MovieInfo = movieInfo;  
        context.MovieInfos.Add(movieInfo);
        context.Movies.Add(movie);

        GenreModel? genre;
        foreach (Dictionary<string, string> keyValuePair in createMovieInfoDTO.Genres)
        {   
            genre = context.Genres.FirstOrDefault(g => g.Name == keyValuePair.Values.First());
            if (genre == null)
                throw new NullReferenceException($"Unknown genre: {keyValuePair.Values.First()}");

            context.MoviesGenres.Add(new MovieGenreModel{ 
                Genre = genre, 
                GenreId = genre.Id, 
                MovieInfo = movieInfo, 
                MovieInfoId = movie.Id
            });
        }
        
        CountryModel? country;
        foreach (Dictionary<string, string> keyValuePair in createMovieInfoDTO.Countries)
        {   
            country = context.Countries.FirstOrDefault(c => c.Name == keyValuePair.Values.First());
            if (country == null)
                throw new NullReferenceException($"Unknown country: {keyValuePair.Values.First()}");

            context.MoviesCountries.Add(new MovieCountryModel{ 
                Country = country, 
                CountryId = country.Id, 
                MovieInfo = movieInfo, 
                MovieInfoId = movie.Id
            });
        }

        await context.SaveChangesAsync();
        
        return mapper.Map<GetMovieDTO>(
            context.Movies
            .Include(movie => movie.MovieInfo)
            .FirstOrDefault(movie => movie.Name == createMovieDTO.Name)!
        );
    }

    public async Task<Hashtable> DeleteMovie(string name) {
        var movies = await context.Movies.ToListAsync();
        context.Movies.Remove(movies.Find(c => c.Name == name)!);
        await context.SaveChangesAsync();
        return new Hashtable {
            { "message", $"Movie with name {name} was deleted" },
            { "status", 200 },
        };
    }

    public async Task<GetMovieDTO> GetMovie(string name) {   
        var movies = await context.Movies.Include(m => m.MovieInfo).ToListAsync();
        return mapper.Map<GetMovieDTO>(movies.FirstOrDefault(c => c.Name == name));
    }

    public async Task<List<GetMovieDTO>> GetMovies() {
        var movies = await context.Movies.ToListAsync();
        return movies.Select(mapper.Map<GetMovieDTO>).ToList();
    }

    public Task<GetMovieDTO> UpdateMovie(UpdateMovieDTO updateMovieDTO)
    {
        throw new NotImplementedException();
    }
}