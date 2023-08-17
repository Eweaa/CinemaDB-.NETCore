using Cinema_DB.Application.Directors.Commands.CreateDirector;
using Cinema_DB.Application.Directors.Commands.DeleteDirector;
using Cinema_DB.Business.Interfaces;
using Cinema_DB.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ApiControllerBase
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<long>> Create(CreateDirectorCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(long Id)
        {
            await Mediator.Send(new DeleteDirectorCommand(Id));
            return NoContent();
        }
    }
}
