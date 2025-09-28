using Sprint_1_Oracle_C_.Models;

namespace Sprint_1_Oracle_C_.Repositories;

public interface INewsRepository
{
    Task<IEnumerable<News>> GetAllAsync();
    Task<News?> GetByIdAsync(int id);
    Task AddAsync(News noticia);
    Task UpdateAsync(News noticia);
    Task DeleteAsync(int id);
}
