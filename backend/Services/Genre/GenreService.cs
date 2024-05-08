using System.Collections;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Kinopoisk.Services.Genre;


public class GenreService : IGenreService
{
    private readonly IMapper mapper;
    private readonly DataContext context;
    public GenreService(IMapper m, DataContext c) {   
        mapper = m;
        context = c;
    }
    public async Task<GenreDTO> AddGenre(GenreDTO genreDTO)
    {
        context.Genres.Add(mapper.Map<GenreModel>(genreDTO));
        await context.SaveChangesAsync();
        return genreDTO;

    }

    public async Task<Hashtable> DeleteGenre(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<GenreDTO> GetGenre(int id)
    {
        var genres = await context.Genres.ToListAsync();
        return mapper.Map<GenreDTO>(genres.FirstOrDefault(c => c.Id == id));
    }
    public async Task<List<GenreDTO>> GetGenres()
    {
        var genres = await context.Genres.ToListAsync();
        return genres.Select(mapper.Map<GenreDTO>).ToList();
    }

    public async Task<GenreDTO> UpdateGenre(GenreDTO genreDTO)
    {
        throw new NotImplementedException();
    }
}