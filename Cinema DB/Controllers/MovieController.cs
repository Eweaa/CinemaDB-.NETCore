using AutoMapper;
using Cinema_DB.Business.Interfaces;
using Cinema_DB.Business.Repos;
using Cinema_DB.Data.Models;
using Cinema_DB.Helper.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Cinema_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
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
        public IActionResult CreateMovie(Movie movie)
        {
            if (movie == null)
                return BadRequest(ModelState);

            var movies = _movie.GetMovies().Where(m => m.Name == movie.Name).FirstOrDefault();

            if (movies != null)
            {
                ModelState.AddModelError("", "Movie Already Exists");
                return StatusCode(422, ModelState);
            }

            if (!_movie.CreateMovie(movie))
            {
                ModelState.AddModelError("", "Something went wrong while Saving");
                return StatusCode(500, ModelState);
            }

            return Ok(movie);
        }

    }
}
