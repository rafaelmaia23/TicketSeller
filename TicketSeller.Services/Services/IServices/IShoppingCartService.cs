using FluentResults;
using TicketSeller.Models.Dtos.ShoppingCartDto;
using TicketSeller.Models.Stripe;

namespace TicketSeller.Services.Services.IServices;

public interface IShoppingCartService
{
    Result<ReadShoppingCartDto> AddShoppingCart(CreateShoppingCartDto createShoppingCartDto, string userId);
    Result DeleteShoppingCart(int id);
    ReadShoppingCartDto GetShoppingCartById(int id);
    Result Order(int id, StripeCard card);
    Result<ReadShoppingCartDto> PutShoppingCart(int id, UpdateShoppingCartDto updateShoppingCartDto);
}
