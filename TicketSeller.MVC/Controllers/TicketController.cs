using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketSeller.Models.Dtos.TicketDto;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public IActionResult GetTickets()
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        Result<List<ReadTicketDto>> result = _ticketService.GetTickets(userId);
        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public IActionResult GetTicketById(int id)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        Result<ReadTicketDto> result = _ticketService.GetTicketById(id, userId);
        if (result.IsFailed) return Conflict(result.Reasons);
        if(result == null) return NotFound();
        return Ok(result.Value);
    }
   
}
