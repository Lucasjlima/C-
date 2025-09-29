using Sprint_1_Oracle_C_.Dtos;
using Sprint_1_Oracle_C_.Models;
using Sprint_1_Oracle_C_.Repositories;
using System.Threading.Tasks;

namespace Sprint_1_Oracle_C_.Service;

public class NewsService
{
    private readonly INewsRepository _repository;

    public NewsService(INewsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<NewsResponseDto>> GetAllNews()
    {
        var news = await _repository.GetAllAsync();
        return news.Select(n => new NewsResponseDto
        {
            Title = n.Title,
            Source = n.Source,
            PublishedAt = n.PublishedAt,
            CreatedAt = n.CreatedAt,
        }).ToList();
    }

    public async Task<NewsResponseDto?> GetByIdAsync(int id)
    {
        var news = await _repository.GetByIdAsync(id);
        if (news == null)
        {
            throw new KeyNotFoundException("News not found");
        }
        return new NewsResponseDto
        {
            Title = news.Title,
            Source = news.Source,
            PublishedAt = news.PublishedAt,
            CreatedAt = news.CreatedAt

        };
    }

    public async Task<NewsResponseDto> AddAsync(NewsDto dto)
    {
        var news = new News
        {
            Title = dto.Title,
            Source = dto.Source,
            PublishedAt = dto.PublishedAt,
            CreatedAt = DateTime.UtcNow,

        };

        await _repository.AddAsync(news);
        return new NewsResponseDto
        {
            Title = news.Title,
            Source = news.Source,
            PublishedAt = news.PublishedAt,
            CreatedAt = news.CreatedAt
        };
    }

    public async Task<NewsResponseDto?> UpdateAsync(NewsDto dto, int id)
    {
        var news = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("News not found");
        news.Title = dto.Title;
        news.Source = dto.Source;
        news.PublishedAt = dto.PublishedAt;
        news.CreatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(news);

        return new NewsResponseDto
        {
            Title = news.Title,
            Source = news.Source,
            PublishedAt = news.PublishedAt,
            CreatedAt = news.CreatedAt
        };
    }

    public async Task DeleteAsync(int id)
    {
        var news = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("News not found");
        await _repository.DeleteAsync(id);
    }
}
