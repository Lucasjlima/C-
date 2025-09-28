using Microsoft.EntityFrameworkCore;
using Sprint_1_Oracle_C_.Infrastructure;
using Sprint_1_Oracle_C_.Models;

namespace Sprint_1_Oracle_C_.Repositories;

public class NewsRepository : INewsRepository
{
    private readonly AppDbContext _context;

    public NewsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(News noticia)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        var news = await _context.reports.FindAsync(id);
        if (news != null)
        {
            _context.reports.Remove(news);
            await _context.SaveChangesAsync();
        }
    }
    

    public async Task<IEnumerable<News>> GetAllAsync()
    {
        return await _context.reports.ToListAsync();
    }

    public async Task<News?> GetByIdAsync(int id)
    {
        return await _context.reports.FindAsync(id);
    }

    public async Task UpdateAsync(News noticia)
    {
        _context.reports.Update(noticia);
        await _context.SaveChangesAsync();
    }
}
