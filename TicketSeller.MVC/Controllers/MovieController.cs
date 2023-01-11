using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketSeller.Models.Dtos.MovieDto;
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
    //[Authorize(Roles = "admin")]
    public IActionResult AddMovie([FromBody] CreateMovieDto createMovieDto)
    {
        ReadMovieDto readMovieDto = _movieService.AddMovie(createMovieDto);
        return CreatedAtAction(nameof(GetMovieById), new { id = readMovieDto.Id }, readMovieDto);
    }

    [HttpGet]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        IEnumerable<ReadMovieDto> readMovieDtos = _movieService.GetMovies(skip, take);
        if (readMovieDtos != null) return Ok(readMovieDtos);
        return NotFound();
    }        

    [HttpGet("{id}")]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetMovieById(int id)
    {
        ReadMovieDto readMovieDto = _movieService.GetMovieById(id);
        if(readMovieDto != null) return Ok(readMovieDto);
        return NotFound();
    }

    [HttpGet("Genre/{genreId}")]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetMoviesByGenre(int genreId, [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        IEnumerable<ReadMovieDto> readMovieDto = _movieService.GetMoviesByGenre(genreId, skip, take);
        if (readMovieDto != null) return Ok(readMovieDto);
        return NotFound();
    }

    [HttpGet("Cinema/{cinemaId}")]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetMoviesByCinema(int cinemaId, [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        IEnumerable<ReadMovieDto> readMovieDto = _movieService.GetMoviesByCinema(cinemaId, skip, take);
        if (readMovieDto != null) return Ok(readMovieDto);
        return NotFound();
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "admin")]
    public IActionResult PutMovie(int id, [FromBody] UpdateMovieDto updateMovieDto)
    {
        Result result = _movieService.PutMovie(id, updateMovieDto);
        if (result.IsFailed) return NotFound(result.Reasons);
        return NoContent();
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "admin")]
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
