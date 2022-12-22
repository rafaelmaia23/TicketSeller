using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TicketSeller.Models.Dto.CinemaDto;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private readonly ICinemaService _cinemaService;

    public CinemaController(ICinemaService cinemaService)
    {
        _cinemaService = cinemaService;
    }

    [HttpPost]
    public IActionResult AddCinema([FromBody] CreateCinemaDto createCinemaDto)
    {
        ReadCinemaDto readCinemaDto = _cinemaService.AddCinema(createCinemaDto);
        if(readCinemaDto == null) return Conflict();
        return CreatedAtAction(nameof(GetCinemaById), new { id = readCinemaDto.Id }, readCinemaDto);
    }

    [HttpGet]
    public IActionResult GetCinemas()
    {
        IEnumerable<ReadCinemaDto> readCinemaDtos = _cinemaService.GetCinemas();
        if (readCinemaDtos != null) return Ok(readCinemaDtos);
        return NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult GetCinemaById(int id)
    {
        ReadCinemaDto readCinemaDto = _cinemaService.GetCinemaById(id);
        if(readCinemaDto != null) return Ok(readCinemaDto);
        return NotFound();
    }

    [HttpGet("Movie/{movieId}")]
    public IActionResult GetCinemasByMovie(int movieId)
    {
        IEnumerable<ReadCinemaDto> readCinemaDtos = _cinemaService.GetCinemasByMovie(movieId);
        if (readCinemaDtos != null) return Ok(readCinemaDtos);
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult PutCinema(int id, [FromBody] UpdateCinemaDto updateCinemaDto)
    {
        Result result = _cinemaService.PutCinema(id, updateCinemaDto);
        if (result.IsSuccess) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCinema(int id)
    {
        Result result = _cinemaService.DeleteCinema(id);
        if (result != null)
        {
            if (result.IsFailed) return Conflict(result.Errors);
            if (result.IsSuccess) return NoContent();
        }
        return NotFound();
    }
}
