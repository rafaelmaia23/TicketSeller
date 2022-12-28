using FluentResults;
using TicketSeller.Models.Dtos.MovieSessionDto;

namespace TicketSeller.Services.Services.IServices;

public interface IMovieSessionService
{
    ReadMovieSessionDto AddMovieSessions(CreateMovieSessionDto createMovieSessionDto);
    IEnumerable<ReadMovieSessionDto> GetMovieSessions();
    ReadMovieSessionDto GetMovieSessionById(int id);
    IEnumerable<ReadMovieSessionDto> GetMovieSessionsByCinema(int cinemaId);
    IEnumerable<ReadMovieSessionDto> GetMovieSessionsByMovie(int movieId);
    IEnumerable<ReadMovieSessionDto> GetMovieSessionsByGenre(int genreId);
    Result PutMovieSession(int id, UpdateMovieSessionDto updateMovieSessionDto);
    Result DeleteMovieSession(int id);        
}
