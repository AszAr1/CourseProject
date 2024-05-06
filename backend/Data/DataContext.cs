using Microsoft.EntityFrameworkCore;

namespace Kinopoisk.Data;

public class DataContext : DbContext {
    public DataContext(DbContextOptions options) : base(options) {}
    public DbSet<MovieInfoModel> MovieInfos => Set<MovieInfoModel>();
    public DbSet<MovieModel> Movies => Set<MovieModel>();
    public DbSet<CountryModel> Countries => Set<CountryModel>();
    public DbSet<MovieGenreModel> Genres => Set<MovieGenreModel>();
    public DbSet<MovieCountryModel> MovieCountries => Set<MovieCountryModel>();

}