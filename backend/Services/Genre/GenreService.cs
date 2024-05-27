using System.Collections;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Kinopoisk.Services.Genre;


public class GenreService : IGenreService {
    private readonly IMapper mapper;
    private readonly DataContext context;

    public GenreService(IMapper m, DataContext c) {     
        mapper = m;
        context = c;
    }
    public async Task<GenreDTO> CreateGenre(GenreDTO genreDTO) {
        GenreModel genre = mapper.Map<GenreModel>(genreDTO);
        context.Genres.Add(genre);
        await context.SaveChangesAsync();
        return genreDTO;
    }
    public async Task<Hashtable> DeleteGenre(string name) {
        var genres = await context.Genres.ToListAsync();
        context.Genres.Remove(genres.Find(c => c.Name == name)!);
        await context.SaveChangesAsync();
        return new Hashtable {
            { "message", $"Movie with name {name} was deleted" },
            { "status", 200 },
        };
    }
    public async Task<GenreDTO> GetGenre(string name) {
        var genres = await context.Genres.ToListAsync();
        return mapper.Map<GenreDTO>(genres.FirstOrDefault(c => c.Name == name));
    }
    public async Task<List<GenreDTO>> GetGenres() {
        var genres = await context.Genres.ToListAsync();
        return genres.Select(mapper.Map<GenreDTO>).ToList();
    }
    public Task<GenreDTO> UpdateGenre(GenreDTO genreDTO) {
        throw new NotImplementedException();
    }
}