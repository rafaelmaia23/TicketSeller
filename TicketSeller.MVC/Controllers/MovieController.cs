using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TicketSeller.Models.Dto.MovieDto;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateMovieDto createMovieDto)
    {
        ReadMovieDto readMovieDto = _movieService.AddMovie(createMovieDto);
        return CreatedAtAction(nameof(GetMovieById), new { id = readMovieDto.Id }, readMovieDto);
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
        IEnumerable<ReadMovieDto> readMovieDtos = _movieService.GetMovies();
        if (readMovieDtos != null) return Ok(readMovieDtos);
        return NotFound();
    }        

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        ReadMovieDto readMovieDto = _movieService.GetMovieById(id);
        if(readMovieDto != null) return Ok(readMovieDto);
        return NotFound();
    }

    [HttpGet("Genre/{genreId}")]
    public IActionResult GetMoviesByGenre(int genreId)
    {
        IEnumerable<ReadMovieDto> readMovieDto = _movieService.GetMoviesByGenre(genreId);
        if (readMovieDto != null) return Ok(readMovieDto);
        return NotFound();
    }

    [HttpGet("Cinema/{cinemaId}")]
    public IActionResult GetMoviesByCinema(int cinemaId)
    {
        IEnumerable<ReadMovieDto> readMovieDto = _movieService.GetMoviesByCinema(cinemaId);
        if (readMovieDto != null) return Ok(readMovieDto);
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult PutMovie(int id, [FromBody] UpdateMovieDto updateMovieDto)
    {
        Result result = _movieService.PutMovie(id, updateMovieDto);
        if(result.IsSuccess) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        Result result = _movieService.DeleteMovie(id);
        if(result != null)
        {
            if (result.IsFailed) return Conflict(result.Reasons);
            if (result.IsSuccess) return NoContent();
        }
        return NotFound();
    }
}
