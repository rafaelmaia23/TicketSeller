using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TicketSeller.Models.Dtos.GenreDto;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpPost]
    public IActionResult AddGenre([FromBody] CreateGenreDto createGenreDto)
    {
        ReadGenreDto readGenreDto = _genreService.AddGenre(createGenreDto);
        return CreatedAtAction(nameof(GetGenreById), new { id = readGenreDto.Id }, readGenreDto);
    }

    [HttpGet]
    public IActionResult GetGenres()
    {
        IEnumerable<ReadGenreDto> readGenreDtos = _genreService.GetGenres();
        if (readGenreDtos != null) return Ok(readGenreDtos);
        return NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult GetGenreById(int id)
    {
        ReadGenreDto readGenreDto = _genreService.GetGenreById(id);
        if (readGenreDto != null) return Ok(readGenreDto);
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult PutGenre(int id, [FromBody] UpdateGenreDto updateGenreDto)
    {
        Result result = _genreService.PutGenre(id, updateGenreDto);
        if (result.IsSuccess) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGenre(int id)
    {
        Result result = _genreService.DeleteGenre(id);
        if (result != null)
        {
            if (result.IsFailed) return Conflict(result.Reasons);
            if (result.IsSuccess) return NoContent();
        }
        return NotFound();
    }

}
