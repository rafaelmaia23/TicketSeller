using AutoMapper;
using TicketSeller.Models.Dto.CinemaDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, ReadCinemaDto>()
                .ForMember(cinema => cinema.MovieSessions, opts => opts
                .MapFrom(cinema => cinema.MovieSessions.Select(
                    m => new { m.Id, m.MovieId, m.Movie.Title, m.MovieRoomNumber, m.StartDateTime, m.EndDateTime})));
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
