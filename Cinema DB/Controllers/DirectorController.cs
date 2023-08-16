using Cinema_DB.Business.Interfaces;
using Cinema_DB.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Cinema_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : Controller
    {
        private readonly IDirector _director;
        public DirectorController(IDirector director)
        {
            _director = director;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Director>))]
        public IActionResult GetActors()
        {
            var directors = _director.GetDirectors();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(directors);
        }

        [HttpGet("director/{Id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Director>))]
        [ProducesResponseType(400)]
        public IActionResult GetDirector(int Id)
        {
            if (!_director.DirectorExists(Id))
                return NotFound();

            var director = _director.GetDirector(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(director);
        }
    }
}
