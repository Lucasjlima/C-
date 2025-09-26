using Microsoft.AspNetCore.Mvc;
using TesteApi.DTOS;
using TesteApi.Entities;
using TesteApi.Services;

namespace TesteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _service;

        public MovieController(MovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieResponseDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<MovieResponseDto> GetById(int id)
        {
            var movie = _service.GetById(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        public ActionResult<MovieResponseDto> Create(MovieCreateDto dto)
        {
            var movie = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MovieUpdateDto dto)
        {
            var success = _service.Update(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _service.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
