﻿using AutoMapper;
using TicketSeller.Models.Dtos.MovieSessionDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles;

public class MovieSessionProfile : Profile
{
    public MovieSessionProfile()
    {

        CreateMap<MovieSession, ReadMovieSessionDto>();
        CreateMap<CreateMovieSessionDto, MovieSession>();
        CreateMap<UpdateMovieSessionDto, MovieSession>();
    }
}
