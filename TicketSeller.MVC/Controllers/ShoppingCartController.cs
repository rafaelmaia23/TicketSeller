using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketSeller.Models.Dtos.ShoppingCartDto;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;
    }

    [HttpPost]
    public IActionResult AddShoppingCart([FromBody] CreateShoppingCartDto createShoppingCartDto)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        Result<ReadShoppingCartDto> result = _shoppingCartService.AddShoppingCart(createShoppingCartDto, userId);
        if (result.IsFailed) return Conflict(result.Reasons);
        return CreatedAtAction(nameof(GetShoppingCartById), new { id = result.Value.Id }, result.Value);
    }

    [HttpGet("{id}")]
    public IActionResult GetShoppingCartById(int id)
    {
        ReadShoppingCartDto readShoppingCartDto = _shoppingCartService.GetShoppingCartById(id);
        if (readShoppingCartDto == null) return NotFound();
        return Ok(readShoppingCartDto);
    }
}
