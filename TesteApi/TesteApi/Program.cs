using Microsoft.EntityFrameworkCore;
using TesteApi.Infrastructure;
using TesteApi.Repositories;
using TesteApi.Services;
using TesteApi.Infrastructure;
using TesteApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configura EF Core com banco em mem�ria
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TestApiDB"));

// Inje��o de depend�ncia
builder.Services.AddScoped<IMovieRepository, EfMovieRepository>();
builder.Services.AddScoped<MovieService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();