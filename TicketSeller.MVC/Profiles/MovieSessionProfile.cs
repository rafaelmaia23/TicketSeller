using AutoMapper;
using TicketSeller.Models.Dto.CinemaDto;
using TicketSeller.Models.Dto.MovieSessionDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles
{
    public class MovieSessionProfile : Profile
    {
        public MovieSessionProfile()
        {

            CreateMap<MovieSession, ReadMovieSessionDto>();
            //.ForPath(movieSession => movieSession.Cinema.MovieSessions, opt => opt
            //.MapFrom(movieSession => movieSession.Cinema.MovieSessions            
            //.Select(c => new { c.Id })));
            CreateMap<CreateMovieSessionDto, MovieSession>();
            CreateMap<UpdateMovieSessionDto, MovieSession>();
        }
    }
}
