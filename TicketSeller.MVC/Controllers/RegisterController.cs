﻿using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TicketSeller.Models.Dtos.UserDto;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    private IRegisterService _registerService;

    public RegisterController(IRegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost]
    public IActionResult RegisterUser(CreateUserDto createUserDto)
    {
        Result result = _registerService.RegisterUser(createUserDto);
        if (result.IsFailed) return StatusCode(500);
        return Ok();
    }
}
