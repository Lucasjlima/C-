using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Sprint_1_Oracle_C_.Dtos;
using Sprint_1_Oracle_C_.Infrastructure;
using Sprint_1_Oracle_C_.Service;

namespace Sprint_1_Oracle_C_.Controllers;
[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    private readonly NewsService _service;


    public NewsController(NewsService service)
    {
        _service = service;

    }



    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var news = await _service.GetAllNewsAsync();
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

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateNews([FromBody] NewsUpdateDto dto, int id)
    {
        try
        {
            var updateNews = await _service.UpdateAsync(dto, id);
            return Ok(updateNews);
        } catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }


    [HttpPatch("{id:int}")]
    public async Task<IActionResult> UpdateNewsPatch(int id, [FromBody] JsonPatchDocument<NewsUpdateDto> patchDto)
    {
        try
        {
            var updatedNews = await _service.PatchAsync(id, patchDto);
            return Ok(updatedNews);
        } catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteNews(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();
        } catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
