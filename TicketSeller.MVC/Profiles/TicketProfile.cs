using AutoMapper;
using TicketSeller.Models.Dtos.TicketDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles;

public class TicketProfile : Profile
{
	public TicketProfile()
	{
		CreateMap<Ticket, ReadTicketDto>()
			.ForMember(t => t.UserName, opt => opt
			.MapFrom(t => t.User.UserName))
			.ForMember(t => t.SeatName, opt => opt
			.MapFrom(t => t.Seat.Name));
	}
}
