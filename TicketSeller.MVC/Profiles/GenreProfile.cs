using AutoMapper;
using TicketSeller.Models.Dto.GenreDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, ReadGenreDto>()
                .ForMember(genre => genre.MovieGenres, opts => opts
                .MapFrom(genre => genre.MovieGenres.Select(
                    m => new { m.MovieId, m.Movie.Title })));
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<UpdateGenreDto, Genre>(); 
        }
    }
}
