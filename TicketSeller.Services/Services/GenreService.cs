using AutoMapper;
using FluentResults;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Dto.GenreDto;
using TicketSeller.Models.Models;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services
{
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

        public IEnumerable<ReadGenreDto> GetGenres()
        {
            IEnumerable<Genre> genres = _unitOfWork.Genre.GetAll();
            List<ReadGenreDto> readGenreDtos = _mapper.Map<List<ReadGenreDto>>(genres);
            return readGenreDtos;
        }

        public ReadGenreDto GetGenreById(int id)
        {
            Genre genre = _unitOfWork.Genre.GetById(id);
            if(genre != null)
            {
                ReadGenreDto readGenreDto = _mapper.Map<ReadGenreDto>(genre);
                return readGenreDto;
            }
            return null;
        }

        public Result PutGenre(int id, UpdateGenreDto updadeGenreDto)
        {
            Genre genre = _unitOfWork.Genre.GetById(id);
            if(genre == null)
            {
                return Result.Fail("Genre Not Found");
            }
            _mapper.Map(updadeGenreDto, genre);
            _unitOfWork.Save();
            return Result.Ok();
        }

        public Result DeleteGenre(int id)
        {
            Genre genre = _unitOfWork.Genre.GetById(id);
            if(genre == null)
            {
                return Result.Fail("Genre Not Found");
            }
            _unitOfWork.Genre.Remove(genre);
            _unitOfWork.Save();
            return Result.Ok();
        }
    }
}
