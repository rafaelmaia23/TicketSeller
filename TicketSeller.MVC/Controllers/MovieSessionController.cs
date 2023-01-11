using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
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
    //[Authorize(Roles = "admin")]
    public IActionResult AddMovieSession([FromBody] CreateMovieSessionDto createMovieSessionDto)
    {
        Result<ReadMovieSessionDto> result = _movieSessionService.AddMovieSessions(createMovieSessionDto);
        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(GetMovieSessionById), new { id = result.Value.Id }, result.Value);
        }
        return Conflict(result.Reasons);
    }

    [HttpGet]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetMovieSessions()
    {
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _movieSessionService.GetMovieSessions();
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
    public IActionResult GetMovieSessionsByCinema(int cinemaId)
    {
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _movieSessionService.GetMovieSessionsByCinema(cinemaId);
        if (readMovieSessionDtos != null) return Ok(readMovieSessionDtos);
        return NotFound();
    }

    [HttpGet("Movie/{movieId}")]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetMovieSessionsByMovie(int movieId)
    {
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _movieSessionService.GetMovieSessionsByMovie(movieId);
        if (readMovieSessionDtos != null) return Ok(readMovieSessionDtos);
        return NotFound();
    }

    [HttpGet("Genre/{genreId}")]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetMovieSessionsByGenre(int genreId)
    {
        IEnumerable<ReadMovieSessionDto> readMovieSessionDtos = _movieSessionService.GetMovieSessionsByGenre(genreId);
        if (readMovieSessionDtos != null) return Ok(readMovieSessionDtos);
        return NotFound();
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "admin")]
    public IActionResult PutMovieSession(int id, [FromBody] UpdateMovieSessionDto updateMovieSessionDto)
    {
        Result result = _movieSessionService.PutMovieSession(id, updateMovieSessionDto);
        if (result.IsSuccess) return NoContent();
        return NotFound();
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
