using AutoMapper;
using TicketSeller.Models.Dtos.ShoppingCartDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles;

public class ShoppingCartProfile : Profile
{
	public ShoppingCartProfile()
	{
		CreateMap<CreateShoppingCartDto, ShoppingCart>();
		CreateMap<UpdateShoppingCartDto, ShoppingCart>();
		CreateMap<ShoppingCart, ReadShoppingCartDto>();
	}
}
