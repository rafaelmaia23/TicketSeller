using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TicketSeller.Models.Dtos.AdressDto;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AdressController : ControllerBase
{
    private readonly IAdressService _adressService;

    public AdressController(IAdressService adressService)
    {
        _adressService = adressService; 
    }

    [HttpPost]
    public IActionResult AddAdress([FromBody] CreateAdressDto createAdressDto)
    {
        ReadAdressDto readAdressDto = _adressService.AddAdress(createAdressDto);
        return CreatedAtAction(nameof(GetAdressById), new { id = readAdressDto.Id }, readAdressDto);
    }

    [HttpGet]
    public IActionResult GetAdresses()
    {
        IEnumerable<ReadAdressDto> readAdressDtos = _adressService.GetAdresses();
        if (readAdressDtos != null) return Ok(readAdressDtos);
        return NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult GetAdressById(int id)
    {
        ReadAdressDto readAdressDto = _adressService.GetAdressById(id);
        if (readAdressDto != null) return Ok(readAdressDto);
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult PutMovie(int id, [FromBody] UpdateAdressDto updateAdressDto)
    {
        Result result = _adressService.PutAdress(id, updateAdressDto);
        if (result.IsSuccess) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        Result result = _adressService.DeleteAdress(id);
        if (result != null)
        {
            if (result.IsFailed) return Conflict(result.Reasons);
            if (result.IsSuccess) return NoContent();
        }
        return NotFound();
    }
}
