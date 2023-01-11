using AutoMapper;
using TicketSeller.Models.Dtos.GenreDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles;

public class GenreProfile : Profile
{
    public GenreProfile()
    {
        CreateMap<Genre, ReadGenreDto>();
        CreateMap<Genre, CustomReadGenreDto>()
            .ForMember(genre => genre.MovieGenres, opts => opts
            .MapFrom(genre => genre.MovieGenres.Select(
                m => new { m.MovieId, m.Movie.Title })));
        CreateMap<CreateGenreDto, Genre>();
        CreateMap<UpdateGenreDto, Genre>(); 
    }
}
