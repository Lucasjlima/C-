using Microsoft.EntityFrameworkCore;
using Sprint_1_Oracle_C_.Infrastructure;
using Sprint_1_Oracle_C_.Repositories;
using Sprint_1_Oracle_C_.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// DbContext (SQLite) - COM TRATAMENTO MELHOR
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI: repositories and services
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<NewsService>();
builder.Services.AddHttpClient<NewsApiService>();
builder.Services.Configure<NewsApiService>(builder.Configuration.GetSection("NewsApi"));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// ADICIONE ESTAS LINHAS PARA CRIAR O BANCO AUTOMATICAMENTE
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated(); // Cria o banco se não existir
        Console.WriteLine("? Banco de dados criado/verificado com sucesso!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"? Erro ao criar banco de dados: {ex.Message}");
    }
}

app.MapControllers();

// ROTA DE TESTE SIMPLES - PARA VERIFICAR SE A API ESTÁ FUNCIONANDO
app.MapGet("/api/test", () => new
{
    message = "API está funcionando!",
    timestamp = DateTime.Now,
    status = "OK"
});

app.Run();