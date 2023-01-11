using FluentResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TicketSeller.Models.Dtos.MovieSessionDto;
using TicketSeller.Models.Models;

namespace TicketSeller.Services.Services.IServices;

public interface IMovieSessionService
{
    Result<ReadMovieSessionDto> AddMovieSessions(CreateMovieSessionDto createMovieSessionDto);
    IEnumerable<ReadMovieSessionDto> GetMovieSessions(int skip, int take);
    ReadMovieSessionDto GetMovieSessionById(int id);
    IEnumerable<ReadMovieSessionDto> GetMovieSessionsByCinema(int cinemaId, int skip, int take);
    IEnumerable<ReadMovieSessionDto> GetMovieSessionsByMovie(int movieId, int skip, int take);
    IEnumerable<ReadMovieSessionDto> GetMovieSessionsByGenre(int genreId, int skip, int take);
    Result PutMovieSession(int id, UpdateMovieSessionDto updateMovieSessionDto);
    Result DeleteMovieSession(int id);
    //Result PatchMovieSession(int id, JsonPatchDocument<UpdateMovieSessionDto> jsonPatchDocument, ModelStateDictionary modelState);

}
