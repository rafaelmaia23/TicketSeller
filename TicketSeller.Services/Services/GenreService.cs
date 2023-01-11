using AutoMapper;
using FluentResults;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Dtos.GenreDto;
using TicketSeller.Models.Models;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class GenreService : IGenreService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public ReadGenreDto AddGenre(CreateGenreDto createGenreDto)
    {
        Genre genre = _mapper.Map<Genre>(createGenreDto);
        _unitOfWork.Genre.Add(genre);
        _unitOfWork.Save();
        return _mapper.Map<ReadGenreDto>(genre);
    }

    public IEnumerable<ReadGenreDto> GetGenres(int skip, int take)
    {
        IEnumerable<Genre> genres = _unitOfWork.Genre.GetAll().Skip(skip).Take(take);
        List<ReadGenreDto> readGenreDtos = _mapper.Map<List<ReadGenreDto>>(genres);
        return readGenreDtos;
    }

    public IEnumerable<CustomReadGenreDto> GetMoviesListOfGenres(int skip, int take)
    {
        IEnumerable<Genre> genres = _unitOfWork.Genre.GetAll().Skip(skip).Take(take);
        List<CustomReadGenreDto> customReadGenreDtos = _mapper.Map<List<CustomReadGenreDto>>(genres);
        return customReadGenreDtos;
    }

    public ReadGenreDto GetGenreById(int id)
    {
        Genre genre = _unitOfWork.Genre.GetById(x => x.Id == id);
        if(genre != null)
        {
            ReadGenreDto readGenreDto = _mapper.Map<ReadGenreDto>(genre);
            return readGenreDto;
        }
        return null;
    }

    public CustomReadGenreDto GetMoviesListOfGenreById(int movieId)
    {
        Genre genre = _unitOfWork.Genre.GetById(x => x.Id == movieId);
        if (genre != null)
        {
            CustomReadGenreDto customReadGenreDto = _mapper.Map<CustomReadGenreDto>(genre);
            return customReadGenreDto;
        }
        return null;
    }

    public Result PutGenre(int id, UpdateGenreDto updadeGenreDto)
    {
        Genre genre = _unitOfWork.Genre.GetById(x => x.Id == id);
        if(genre == null) return Result.Fail("Genre Not Found");
        _mapper.Map(updadeGenreDto, genre);
        _unitOfWork.Save();
        return Result.Ok();
    }

    public Result DeleteGenre(int id)
    {
        Genre genre = _unitOfWork.Genre.GetById(x => x.Id == id);
        if(genre == null) return null;
        if (genre.MovieGenres.Count != 0) return Result.Fail("Cannot delete a Genre that contain Movies");
        _unitOfWork.Genre.Remove(genre);
        _unitOfWork.Save();
        return Result.Ok();
    }

}
