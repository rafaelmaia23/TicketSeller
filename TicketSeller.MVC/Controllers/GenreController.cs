using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
    //[Authorize(Roles = "admin")]
    public IActionResult AddGenre([FromBody] CreateGenreDto createGenreDto)
    {
        ReadGenreDto readGenreDto = _genreService.AddGenre(createGenreDto);
        return CreatedAtAction(nameof(GetGenreById), new { id = readGenreDto.Id }, readGenreDto);
    }

    [HttpGet]
    //[Authorize(Roles = "admin")]
    public IActionResult GetGenres([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        IEnumerable<ReadGenreDto> readGenreDtos = _genreService.GetGenres(skip, take);
        if (readGenreDtos != null) return Ok(readGenreDtos);
        return NotFound();
    }

    [HttpGet("MoviesList")]
    //[Authorize(Roles = "admin")]
    public IActionResult GetMoviesListOfGenres([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        IEnumerable<CustomReadGenreDto> customReadGenreDtos = _genreService.GetMoviesListOfGenres(skip, take);
        if (customReadGenreDtos != null) return Ok(customReadGenreDtos);
        return NotFound();
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "admin")]
    public IActionResult GetGenreById(int id)
    {
        ReadGenreDto readGenreDto = _genreService.GetGenreById(id);
        if (readGenreDto != null) return Ok(readGenreDto);
        return NotFound();
    }

    [HttpGet("MoviesList/{movieId}")]
    //[Authorize(Roles = "admin")]
    public IActionResult GetMoviesListOfGenreById(int movieId)
    {
        CustomReadGenreDto customReadGenreDto = _genreService.GetMoviesListOfGenreById(movieId);
        if (customReadGenreDto != null) return Ok(customReadGenreDto);
        return NotFound();
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "admin")]
    public IActionResult PutGenre(int id, [FromBody] UpdateGenreDto updateGenreDto)
    {
        Result result = _genreService.PutGenre(id, updateGenreDto);
        if (result.IsSuccess) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "admin")]
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
