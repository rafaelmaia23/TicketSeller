using AutoMapper;
using TicketSeller.Models.Dto.CinemaDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, ReadCinemaDto>();
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
