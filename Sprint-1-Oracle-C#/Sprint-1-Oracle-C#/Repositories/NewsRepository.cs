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

    public async Task AddAsync(News reports)
    {
        _context.Reports.Add(reports);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var news = await _context.Reports.FindAsync(id);
        if (news != null)
        {
            _context.Reports.Remove(news);
            await _context.SaveChangesAsync();
        }
    }
    

    public async Task<IEnumerable<News>> GetAllAsync()
    {
        return await _context.Reports.ToListAsync();
    }

    public async Task<News?> GetByIdAsync(int id)
    {
        return await _context.Reports.FindAsync(id);
    }

    public async Task UpdateAsync(News noticia)
    {
        _context.Reports.Update(noticia);
        await _context.SaveChangesAsync();
    }
}
