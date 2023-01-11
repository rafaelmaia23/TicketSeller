using AutoMapper;
using TicketSeller.Models.Dtos.SeatDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles;

public class SeatProfile : Profile
{
	public SeatProfile()
	{
		CreateMap<Seat, ReadSeatDto>();
	}
}
