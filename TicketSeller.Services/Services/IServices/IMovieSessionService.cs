using FluentResults;
using TicketSeller.Models.Dto.MovieSessionDto;

namespace TicketSeller.Services.Services.IServices
{
    public interface IMovieSessionService
    {
        ReadMovieSessionDto AddMovieSessions(CreateMovieSessionDto createMovieSessionDto);
        IEnumerable<ReadMovieSessionDto> GetMovieSessions();
        ReadMovieSessionDto GetMovieSessionById(int id);
        IEnumerable<ReadMovieSessionDto> GetMovieSessionsByCinema(int cinemaId);
        Result PutMovieSession(int id, UpdateMovieSessionDto updateMovieSessionDto);
        Result DeleteMovieSession(int id);
    }
}
