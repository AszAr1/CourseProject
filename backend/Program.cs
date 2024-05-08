global using Kinopoisk.Models;
global using Kinopoisk.Services.Movie;
global using Kinopoisk.Services.Country;
global using Kinopoisk.Services.Genre;
global using Kinopoisk.DTOs.Movie;
global using Kinopoisk.DTOs.MovieInfo;
global using Kinopoisk.DTOs.Country;
global using Kinopoisk.DTOs.Genre;
global using Kinopoisk.Data;
global using Kinopoisk.Enums;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


string connectionString = builder.Configuration.GetConnectionString("Default")!;
builder.Services.AddDbContext<DataContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IGenreService, GenreService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();