using AutoMapper;
using Sprint_1_Oracle_C_.Dtos;
using Sprint_1_Oracle_C_.Models;
using Sprint_1_Oracle_C_.Repositories;

namespace Sprint_1_Oracle_C_.Service;

public class NewsService
{
    private readonly INewsRepository _repository;
    private readonly IMapper _mapper;

    public NewsService(INewsRepository repository, IMapper mapper   )
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NewsResponseDto>> GetAllNews()
    {
        var news = await _repository.GetAllAsync();
        return _mapper.Map<List<NewsResponseDto>>(news);
    }

    public async Task<NewsResponseDto?> GetByIdAsync(int id)
    {
        var news = await _repository.GetByIdAsync(id);
        if (news == null)
        {
            throw new KeyNotFoundException("News not found");
        }
        return _mapper.Map<NewsResponseDto>(news);
    }

    public async Task<NewsResponseDto> AddAsync(NewsDto dto)
    {
        News news = _mapper.Map<News>(dto);
        await _repository.AddAsync(news);
        return _mapper.Map<NewsResponseDto>(news);
    }

    public async Task<NewsResponseDto?> UpdateAsync(NewsDto dto, int id)
    {
        var news = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("News not found");
        _mapper.Map(dto, news);
        news.CreatedAt = DateTime.Now;

        await _repository.UpdateAsync(news);

        return _mapper.Map<NewsResponseDto>(news);
    }

    public async Task DeleteAsync(int id)
    {
        var news = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("News not found");
        await _repository.DeleteAsync(id);
    }
}
