using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSeller.Models.Dto.MovieDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, ReadMovieDto>()
                .ForMember(movie => movie.MovieGenres, opts => opts
                .MapFrom(movie => movie.MovieGenres.Select(
                    g => new {g.GenreId, g.Genre.Name})));
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<UpdateMovieDto, Movie>();
        }
    }
}
