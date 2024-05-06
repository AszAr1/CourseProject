global using Kinopoisk.Controllers;
global using Kinopoisk.Models;
global using Kinopoisk.Services.Movie;
global using Kinopoisk.DTOs.Movie;
global using Kinopoisk.DTOs.MovieInfo;
global using Kinopoisk.Data;

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

var app = builder.Build();

 if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();