using System.Collections;
using Newtonsoft.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Kinopoisk.Services.Movie;


public class MovieService : IMovieService {
    private readonly IMapper mapper;
    private readonly DataContext context;
    private readonly IConfiguration configuration;
    private readonly IMovieInfoService movieInfoService;

    public MovieService(IMapper m, DataContext c, IConfiguration config, IMovieInfoService movieInfoService) {
        mapper = m;
        context = c;
        configuration = config;
        this.movieInfoService = movieInfoService;
    }
    public async Task<GetMovieDTO> CreateMovie(CreateUpdateMovieDTO createUpdateMovieDTO) {
        MovieModel movie = mapper.Map<MovieModel>(createUpdateMovieDTO);

        var movieFile = createUpdateMovieDTO.File;

        if (movieFile == null) 
            throw new ArgumentException("Could get movie file");

        string filePath = Path.Join(MovieModel.BASE_PATH, createUpdateMovieDTO.File?.FileName);

        using (FileStream fileStream = new FileStream(filePath, FileMode.Create)) {
            await movieFile.CopyToAsync(fileStream);
        }

        var fileURI = new Uri(MovieModel.BASE_URI + filePath);

        movie.Uri = fileURI.ToString();

        if (createUpdateMovieDTO.Name == null)
            throw new NullReferenceException("Could not get movie name from CreateUpdateMovieDTO");
        
        HttpClient client = new HttpClient();
        string url = $"https://kinopoiskapiunofficial.tech/api/v2.1/films/search-by-keyword?keyword={createUpdateMovieDTO.Name}&page=1";
        Console.WriteLine($"URL: {url}");
        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url)
        };
        request.Headers.Add("X-API-KEY", configuration.GetSection("API_KEY").Value);

        HttpResponseMessage responseJson = await client.SendAsync(request);
    
        var json = await responseJson.Content.ReadAsStringAsync();
        var movieData = JsonConvert.DeserializeObject<JsonSearchResponse>(json);
        Console.WriteLine(movieData);

        if (movieData == null) 
            throw new NullReferenceException("Could not get movie info");

        CreateUpdateMovieInfoDTO createUpdateMovieInfoDTO = movieData.Films[0];

        await movieInfoService.CreateMovieInfo(createUpdateMovieInfoDTO);
        
        MovieInfoModel movieInfo = mapper.Map<MovieInfoModel>(createUpdateMovieInfoDTO);
        movieInfo.Movie = movie;
        movie.MovieInfoId = movieInfo.Id;
        movie.MovieInfo = movieInfo;  
        context.Movies.Add(movie);

        await context.SaveChangesAsync();
        
        return mapper.Map<GetMovieDTO>(
            context.Movies.Include(m => m.MovieInfo).FirstOrDefault(m => m.Name == createUpdateMovieDTO.Name)!
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
        var movies = await context.Movies.Include(m => m.MovieInfo).ToListAsync();
        return movies.Select(mapper.Map<GetMovieDTO>).ToList();
    }

    public async Task<GetMovieDTO> UpdateMovie(CreateUpdateMovieDTO createUpdateMovieDTO) {
        var movie = await context.Movies
            .Include(m => m.MovieInfo)
            .FirstAsync(m => m.Name == createUpdateMovieDTO.Name);

        if (movie == null) {
            return await CreateMovie(mapper.Map<CreateUpdateMovieDTO>(createUpdateMovieDTO));
        }

        var movieFile = createUpdateMovieDTO.File;

        if (movieFile == null) 
            throw new ArgumentException("Could get movie file");

        string filePath = Path.Join(MovieModel.BASE_PATH, createUpdateMovieDTO.File?.FileName);

        using (FileStream fileStream = new FileStream(filePath, FileMode.Create)) {
            await movieFile.CopyToAsync(fileStream);
        }

        var fileURI = new Uri(MovieModel.BASE_URI + filePath);

        var newMovie = mapper.Map<MovieModel>(createUpdateMovieDTO);
        newMovie.Uri = fileURI.ToString();
        context.Movies.Update(newMovie);

        await context.SaveChangesAsync();   

        return mapper.Map<GetMovieDTO>(newMovie);
    }
}