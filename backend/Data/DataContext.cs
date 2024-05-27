using Microsoft.EntityFrameworkCore;

namespace Kinopoisk.Data;

public class DataContext : DbContext {
    public DataContext(DbContextOptions options) : base(options) {}
    public DbSet<MovieInfoModel> MovieInfos => Set<MovieInfoModel>();
    public DbSet<MovieModel> Movies => Set<MovieModel>();
    public DbSet<CountryModel> Countries => Set<CountryModel>();
    public DbSet<GenreModel> Genres => Set<GenreModel>();
    public DbSet<MovieCountryModel> MoviesCountries => Set<MovieCountryModel>();
    public DbSet<MovieGenreModel> MoviesGenres => Set<MovieGenreModel>();
    public DbSet<UserModel> Users => Set<UserModel>();
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<UserModel>().HasData(
            new UserModel {
                Username = "Admin",
                Email = "admin@gmail.com",
                Password = "Admin",
                isActive = true, 
                IsAdmin = true
            }
        );
    }
}