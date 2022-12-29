using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LogoutController : ControllerBase
{
    private ILogoutService _logoutService;

    public LogoutController(ILogoutService logoutService)
    {
        _logoutService = logoutService;
    }

    [HttpPost]
    public IActionResult LogoutUser()
    {
        Result result = _logoutService.LogoutUser();
        if(result.IsFailed) return Unauthorized(result.Reasons);
        return Ok(result.Successes.FirstOrDefault());
    }
}
