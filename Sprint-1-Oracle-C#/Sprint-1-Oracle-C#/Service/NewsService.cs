using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Sprint_1_Oracle_C_.Dtos;
using Sprint_1_Oracle_C_.Models;
using Sprint_1_Oracle_C_.Repositories;
using System.ComponentModel.DataAnnotations;

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

    public async Task<IEnumerable<NewsResponseDto>> GetAllNewsAsync()
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

    public async Task<NewsResponseDto?> UpdateAsync(NewsUpdateDto dto, int id)
    {
        var news = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("News not found");
        _mapper.Map(dto, news);
        news.CreatedAt = DateTime.Now;

        await _repository.UpdateAsync(news);

        return _mapper.Map<NewsResponseDto>(news);
    }

    public async Task<NewsResponseDto?> PatchAsync(int id, JsonPatchDocument<NewsUpdateDto> patchDto)
    {
        var existingNews = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("News not found");

        var newsToPatch = _mapper.Map<NewsUpdateDto>(existingNews);
        patchDto.ApplyTo(newsToPatch);

        var validationContext = new ValidationContext(newsToPatch);
        var validationResults = new List<ValidationResult>();

        if (!Validator.TryValidateObject(newsToPatch, validationContext, validationResults, true))
        {
            throw new ArgumentException($"Validação falhou: {string.Join(", ", validationResults.Select(v => v.ErrorMessage))}");
        }

        _mapper.Map(newsToPatch, existingNews);
        existingNews.CreatedAt = DateTime.Now;

        
        await _repository.UpdateAsync(existingNews);

        return _mapper.Map<NewsResponseDto>(existingNews);
    }

    public async Task DeleteAsync(int id)
    {
        var news = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("News not found");
        await _repository.DeleteAsync(id);
    }
}
