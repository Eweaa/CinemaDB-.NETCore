using AutoMapper;
using Cinema_DB.Application.Actors.Commands.CreateActor;
using Cinema_DB.Application.Actors.Commands.DeleteActor;
using Cinema_DB.Application.Movies.Commands.CreateMovie;
using Cinema_DB.Application.Movies.Commands.DeleteMovie;
using Cinema_DB.Business.Interfaces;
using Cinema_DB.Domain.Entities;
using Cinema_DB.Helper.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Cinema_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ApiControllerBase
    {
        private readonly IMovie _movie;
        private readonly IMapper _mapper;
        public MovieController(IMovie movie, IMapper mapper)
        {
            _movie = movie;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MovieVM>))]
        public IActionResult GetMovies()
        {
            var movies = _movie.GetMovies();
            var moviesvm = _mapper.Map<List<MovieVM>>(movies);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(moviesvm);
        }

        [HttpGet("movie/{Id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Movie>))]
        [ProducesResponseType(400)]
        public IActionResult GetMovie(int Id)
        {
            if (!_movie.MovieExists(Id))
                return NotFound();

            var movie = _movie.GetMovie(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(movie);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<long>> Create(CreateMovieCommand command)
        {
            return await Mediator.Send(command);
        }


        [HttpDelete("{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(long Id)
        {
            await Mediator.Send(new DeleteMovieCommand(Id));
            return NoContent();
        }

    }
}
