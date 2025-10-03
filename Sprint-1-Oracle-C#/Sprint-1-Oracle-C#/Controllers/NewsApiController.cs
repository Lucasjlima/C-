using Microsoft.AspNetCore.Mvc;
using Sprint_1_Oracle_C_.Service;

namespace Sprint_1_Oracle_C_.Controllers;
[ApiController]
[Route("api/[controller]")]
public class NewsApiController : ControllerBase
{
    private readonly NewsApiService _newsApiService;

    public NewsApiController(NewsApiService newsApiService)
    {
        _newsApiService = newsApiService;
    }


    [HttpGet("external")]
    public async Task<IActionResult> GetExternalNews()
    {
        try
        {
            var news = await _newsApiService.GetTopHeadlinesAsync();
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        } catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}
