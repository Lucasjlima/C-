using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sprint_1_Oracle_C_.Dtos;
using Sprint_1_Oracle_C_.Service;

namespace Sprint_1_Oracle_C_.Controllers;
[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly NewsService _service;
    private readonly IMapper _mapper;


    public NewsController(NewsService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var news = await _service.GetAllNews();
            return Ok(news);
        } catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var n = await _service.GetByIdAsync(id);
        if (n == null) return NotFound();
        return Ok(n);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNews([FromBody] NewsDto dto)
    {
        try
        {
            var news = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = news.Id }, news);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
