using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TicketSeller.Models.Dtos.MovieSessionDto;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieSessionController : ControllerBase
{
    private readonly IMovieSessionService _movieSessionService;

    public MovieSessionController(IMovieSessionService movieSessionService)
    {
        _movieSessionService = movieSessionService;
    }

    [HttpPost]
    public IActionResult AddMovieSession([FromBody] CreateMovieSessionDto createMovieSessionDto)
    {
        ReadMovieSessionDto readMovieSessionDto = _movieSessionService.AddMovieSessions(createMovieSessionDto);
        return CreatedAtAction(nameof(GetMovieSessionById), new { id = readMovieSessionDto.Id }, readMovieSessionDto);
    }

    [HttpGet]
    public IActionResult GetMovieSessions()
    {
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _movieSessionService.GetMovieSessions();
        if(readMovieSessionDtos != null) return Ok(readMovieSessionDtos);
        return NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieSessionById(int id)
    {
        ReadMovieSessionDto readMovieSessionDto = _movieSessionService.GetMovieSessionById(id);
        if(readMovieSessionDto != null) return Ok(readMovieSessionDto);
        return NotFound();
    }

    [HttpGet("Cinema/{cinemaId}")]
    public IActionResult GetMovieSessionsByCinema(int cinemaId)
    {
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _movieSessionService.GetMovieSessionsByCinema(cinemaId);
        if (readMovieSessionDtos != null) return Ok(readMovieSessionDtos);
        return NotFound();
    }

    [HttpGet("Movie/{movieId}")]
    public IActionResult GetMovieSessionsByMovie(int movieId)
    {
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _movieSessionService.GetMovieSessionsByMovie(movieId);
        if (readMovieSessionDtos != null) return Ok(readMovieSessionDtos);
        return NotFound();
    }

    [HttpGet("Genre/{genreId}")]
    public IActionResult GetMovieSessionsByGenre(int genreId)
    {
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _movieSessionService.GetMovieSessionsByGenre(genreId);
        if (readMovieSessionDtos != null) return Ok(readMovieSessionDtos);
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult PutMovieSession(int id, [FromBody] UpdateMovieSessionDto updateMovieSessionDto)
    {
        Result result = _movieSessionService.PutMovieSession(id, updateMovieSessionDto);
        if (result.IsSuccess) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovieSession(int id)
    {
        Result result = _movieSessionService.DeleteMovieSession(id);
        if(result.IsSuccess) return NoContent();
        return NotFound();
    }

}
