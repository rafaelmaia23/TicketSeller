using FluentResults;
using TicketSeller.Models.Dtos.ShoppingCartDto;

namespace TicketSeller.Services.Services.IServices;

public interface IShoppingCartService
{
    Result<ReadShoppingCartDto> AddShoppingCart(CreateShoppingCartDto createShoppingCartDto, string userId);
    ReadShoppingCartDto GetShoppingCartById(int id);
}
