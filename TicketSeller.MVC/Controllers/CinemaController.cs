using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TicketSeller.Models.Dtos.CinemaDto;
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
    //[Authorize(Roles = "admin")]
    public IActionResult AddCinema([FromBody] CreateCinemaDto createCinemaDto)
    {
        ReadCinemaDto readCinemaDto = _cinemaService.AddCinema(createCinemaDto);
        if(readCinemaDto == null) return Conflict("Cannot add a Cinema with an Adress already in use by another Cinema, please use an adress available");
        return CreatedAtAction(nameof(GetCinemaById), new { id = readCinemaDto.Id }, readCinemaDto);
    }

    [HttpGet]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetCinemas([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        IEnumerable<ReadCinemaDto> readCinemaDtos = _cinemaService.GetCinemas(skip, take);
        if (readCinemaDtos != null) return Ok(readCinemaDtos);
        return NotFound();
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetCinemaById(int id)
    {
        ReadCinemaDto readCinemaDto = _cinemaService.GetCinemaById(id);
        if(readCinemaDto != null) return Ok(readCinemaDto);
        return NotFound();
    }

    [HttpGet("Movie/{movieId}")]
    //[Authorize(Roles = "admin, client")]
    public IActionResult GetCinemasByMovie(int movieId, [FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        IEnumerable<ReadCinemaDto> readCinemaDtos = _cinemaService.GetCinemasByMovie(movieId, skip, take);
        if (readCinemaDtos != null) return Ok(readCinemaDtos);
        return NotFound();
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "admin")]
    public IActionResult PutCinema(int id, [FromBody] UpdateCinemaDto updateCinemaDto)
    {
        Result result = _cinemaService.PutCinema(id, updateCinemaDto);
        if (result.IsSuccess) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "admin")]
    public IActionResult DeleteCinema(int id)
    {
        Result result = _cinemaService.DeleteCinema(id);
        if (result != null)
        {
            if (result.IsFailed) return Conflict(result.Reasons);
            if (result.IsSuccess) return NoContent();
        }
        return NotFound();
    }
}
