﻿using FluentResults;
using Microsoft.AspNetCore.Mvc;
using TicketSeller.Models.Dto.MovieDto;
using TicketSeller.Services.IServices;

namespace TicketSeller.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieDto createMovieDto)
        {
            ReadMovieDto readMovieDto = _movieService.AddMovie(createMovieDto);
            return CreatedAtAction(nameof(GetMovieById), new { id = readMovieDto.Id }, readMovieDto);
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            IEnumerable<ReadMovieDto> readMovieDto = _movieService.GetMovies();
            if(readMovieDto != null) return Ok(readMovieDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            ReadMovieDto readMovieDto = _movieService.GetMovieById(id);
            if(readMovieDto != null) return Ok(readMovieDto);
            return NotFound();
        }        

        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, [FromBody] UpdateMovieDto updateMovieDto)
        {
            Result result = _movieService.PutMovie(id, updateMovieDto);
            if(result.IsSuccess) return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            Result result = _movieService.DeleteMovie(id);
            if (result.IsSuccess) return NoContent();
            return NotFound();
        }
    }
}