using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TicketSeller.Models.Requests;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost]
    public IActionResult LoginUser(LoginRequest loginRequest)
    {
        Result result = _loginService.LoginUser(loginRequest);
        if (result.IsFailed) return Unauthorized(result.Reasons);
        return Ok(result.Successes.FirstOrDefault());
    }
}
