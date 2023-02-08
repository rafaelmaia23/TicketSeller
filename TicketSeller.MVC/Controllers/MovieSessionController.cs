using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TicketSeller.Models.Dtos.MovieSessionDto;
using TicketSeller.Models.Dtos.SeatDto;
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
    //[Authorize(Roles = "admin")]
    public IActionResult AddMovieSession([FromBody] CreateMovieSessionDto createMovieSessionDto)
    {
        Result<ReadMovieSessionDto> result = _movieSessionService.AddMovieSessions(createMovieSessionDto);
        if (result == null) return Conflict("Movie Room is not available");
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetMovieSessionById), new { id = result.Value.Id }, result.Value);
        }
        return NotFound(result.Reasons);
    }

    [HttpGet]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetMovieSessions([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _movieSessionService.GetMovieSessions(skip, take);
        if(readMovieSessionDtos != null) return Ok(readMovieSessionDtos);
        return NotFound();
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetMovieSessionById(int id)
    {
        ReadMovieSessionDto readMovieSessionDto = _movieSessionService.GetMovieSessionById(id);
        if(readMovieSessionDto != null) return Ok(readMovieSessionDto);
        return NotFound();
    }

    [HttpGet("Cinema/{cinemaId}")]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetMovieSessionsByCinema(int cinemaId, [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _movieSessionService.GetMovieSessionsByCinema(cinemaId, skip, take);
        if (readMovieSessionDtos != null) return Ok(readMovieSessionDtos);
        return NotFound();
    }

    [HttpGet("Movie/{movieId}")]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetMovieSessionsByMovie(int movieId, [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _movieSessionService.GetMovieSessionsByMovie(movieId, skip, take);
        if (readMovieSessionDtos != null) return Ok(readMovieSessionDtos);
        return NotFound();
    }

    [HttpGet("Genre/{genreId}")]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetMovieSessionsByGenre(int genreId, [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _movieSessionService.GetMovieSessionsByGenre(genreId, skip, take);
        if (readMovieSessionDtos != null) return Ok(readMovieSessionDtos);
        return NotFound();
    }

    [HttpGet("Seats/{movieSessionId}")]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetSeatsOfMovieSessionById(int movieSessionId)
    {
        IEnumerable<ReadSeatDto> seats = _movieSessionService.GetSeatsOfMovieSessionById(movieSessionId);
        if (seats != null) return Ok(seats);
        return NotFound();
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "admin")]
    public IActionResult PutMovieSession(int id, [FromBody] UpdateMovieSessionDto updateMovieSessionDto)
    {
        Result result = _movieSessionService.PutMovieSession(id, updateMovieSessionDto);
        if(result == null) return Conflict("Movie Room is not available");
        if (result.IsSuccess) return NoContent();
        return NotFound(result.Reasons);
    }

    //[HttpPatch("{id}")]
    //[Authorize(Roles = "admin")]
    //public IActionResult PatchMovieSession(int id, JsonPatchDocument<UpdateMovieSessionDto> jsonPatchDocument)
    //{
    //    TryValidateModel(jsonPatchDocument);
    //    Result result = _movieSessionService.PatchMovieSession(id, jsonPatchDocument, ModelState);
    //    if (result != null)
    //    {
    //        if (result.IsFailed) return ValidationProblem(ModelState);
    //        if (result.IsSuccess) return NoContent();
    //    }
    //    return NotFound();
    //}

    [HttpDelete("{id}")]
    //[Authorize(Roles = "admin")]
    public IActionResult DeleteMovieSession(int id)
    {
        Result result = _movieSessionService.DeleteMovieSession(id);
        if(result.IsSuccess) return NoContent();
        return NotFound();
    }

}
