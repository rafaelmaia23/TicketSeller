using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketSeller.Models.Dtos.ShoppingCartDto;
using TicketSeller.Models.Stripe;
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
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
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

    [HttpPut("{id}")]
    public IActionResult PutShoppingCart(int id, [FromBody] UpdateShoppingCartDto updateShoppingCartDto)
    {
        Result<ReadShoppingCartDto> result = _shoppingCartService.PutShoppingCart(id, updateShoppingCartDto);
        if (result == null) return NotFound();
        if (result.IsFailed) return Conflict(result.Reasons);
        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteShoppingCart(int id)
    {
        Result result = _shoppingCartService.DeleteShoppingCart(id);
        if (result.IsFailed) return NotFound(result.Reasons);
        return Ok();
    }

    [HttpPost("/{id}/Order")]
    public IActionResult Order(int id, [FromBody] StripeCard card)
    {
        Result result = _shoppingCartService.Order(id, card);
        if (result.IsFailed) return Conflict(result.Reasons);
        return Ok("Order completed with Success");
    }
}
