using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Dtos.CinemaDto;
using TicketSeller.Models.Models;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class CinemaService : ICinemaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CinemaService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;            
    }
    public Result<ReadCinemaDto>? AddCinema(CreateCinemaDto createCinemaDto)
    {
        Adress adress = _unitOfWork.Adress.GetById(x => x.Id == createCinemaDto.AdressId);
        if (adress == null) return null;
        if (adress.Cinema != null) return Result.Fail("Cannot add a Cinema with an Adress already in use by another Cinema, please use an adress available");
        Cinema cinema = _mapper.Map<Cinema>(createCinemaDto);
        _unitOfWork.Cinema.Add(cinema);
        _unitOfWork.Save();
        ReadCinemaDto readCinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
        return Result.Ok(readCinemaDto);
    }      

    public IEnumerable<ReadCinemaDto> GetCinemas(int skip, int take)
    {
        IEnumerable<Cinema> cinemas = _unitOfWork.Cinema.GetAll().Skip(skip).Take(take);
        IEnumerable<ReadCinemaDto> readCinemaDtos = _mapper.Map<List<ReadCinemaDto>>(cinemas);
        return readCinemaDtos;
    }

    public ReadCinemaDto? GetCinemaById(int id)
    {
        Cinema cinema = _unitOfWork.Cinema.GetById(x => x.Id == id);
        if(cinema != null)
        {
            ReadCinemaDto readCinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return readCinemaDto;
        }
        return null;
    }

    public IEnumerable<ReadCinemaDto>? GetCinemasByMovie(int movieId, int skip, int take)
    {
        List<MovieSession> movieSessions = _unitOfWork.MovieSession
            .GetAll()
            .Where(x => x.MovieId == movieId)
            .Skip(skip)
            .Take(take)
            .ToList();
        if (movieSessions == null) return null;
        var cinemas = new List<Cinema>();
        foreach(var movieSession in movieSessions)
        {
            if (cinemas.Contains(movieSession.Cinema) == false) cinemas.Add(movieSession.Cinema);
        }
        return _mapper.Map<IEnumerable<ReadCinemaDto>>(cinemas);
    }

    public Result PutCinema(int id, UpdateCinemaDto updateCinemaDto)
    {
        Cinema cinema = _unitOfWork.Cinema.GetById(x => x.Id == id);
        Adress adress = _unitOfWork.Adress.GetById(x => x.Id == updateCinemaDto.AdressId);
        if (adress == null) return Result.Fail("Adress not found");
        if (cinema == null) return Result.Fail("Cinema not found");
        if ((adress.Cinema != null) & (adress.Cinema != cinema)) return null;
        _mapper.Map(updateCinemaDto, cinema);
        _unitOfWork.Save();
        return Result.Ok();
    }

    public Result? DeleteCinema(int id)
    {
        Cinema cinema = _unitOfWork.Cinema.GetById(x => x.Id == id);
        if (cinema == null) return null;
        if(cinema.MovieSessions.Count != 0) return Result.Fail("Cannot delete a Cinema that have MovieSessions");
        _unitOfWork.Adress.Remove(cinema.Adress);
        _unitOfWork.Cinema.Remove(cinema);
        _unitOfWork.Save();
        return Result.Ok();
    }
}
