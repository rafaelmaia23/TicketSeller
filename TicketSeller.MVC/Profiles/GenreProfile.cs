using AutoMapper;
using TicketSeller.Models.Dto.GenreDto;
using TicketSeller.Models.Dto.MovieDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, ReadGenreDto>();
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<UpdateGenreDto, Genre>(); 
        }
    }
}
