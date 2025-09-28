using Microsoft.EntityFrameworkCore;
using Sprint_1_Oracle_C_.Models;

namespace Sprint_1_Oracle_C_.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<News> reports { get; set; }
}
