using Microsoft.EntityFrameworkCore;
using TesteApi.DTOS;
using TesteApi.Entities;

namespace TesteApi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
