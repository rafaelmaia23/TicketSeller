using AutoMapper;
using TicketSeller.Models.Dtos.MovieDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, ReadMovieDto>()
            .ForMember(movie => movie.MovieGenres, opts => opts
            .MapFrom(movie => movie.MovieGenres.Select(
                g => new { g.GenreId, g.Genre.Name })))
            .ForMember(movie => movie.MovieSessions, opts => opts
            .MapFrom(movie => movie.MovieSessions.Select(
                m => new {m.Id, m.CinemaId, m.Cinema.Name, m.MovieRoomNumber, m.StartDateTime, m.EndDateTime})));
        CreateMap<Movie, CustomReadMovieDto>()
            .ForMember(movie => movie.MovieGenres, opts => opts
            .MapFrom(movie => movie.MovieGenres.Select(
                g => new { g.GenreId, g.Genre.Name })));
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<UpdateMovieDto, Movie>();
    }
}
