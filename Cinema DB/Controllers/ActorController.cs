using AutoMapper;
using Cinema_DB.Business.Interfaces;
using Cinema_DB.Business.Repos;
using Cinema_DB.Data.Models;
using Cinema_DB.Helper.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : Controller
    {
        private readonly IActor _actor;
        private readonly IMapper _mapper;
        public ActorController(IActor actor, IMapper mapper)
        {
            _actor = actor;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ActorVM>))]
        public IActionResult GetActors()
        {
            var actors = _actor.GetActors();
            var actorsvm = _mapper.Map<List<ActorVM>>(actors);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(actorsvm);
        }

        [HttpGet("[controller]/{Id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Actor>))]
        [ProducesResponseType(400)]
        public IActionResult GetActor(int Id)
        {
            if (!_actor.ActorExists(Id))
                return NotFound();

            var actor = _actor.GetActor(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(actor);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateActor(Actor actor)
        {
            if (actor == null)
                return BadRequest(ModelState);

            var actors = _actor.GetActors().Where(a => a.Name == actor.Name).FirstOrDefault();

            if (actors != null)
            {
                ModelState.AddModelError("", "Actor Already Exists");
                return StatusCode(422, ModelState);
            }

            if (!_actor.CreateActor(actor))
            {
                ModelState.AddModelError("", "Something went wrong while Saving");
                return StatusCode(500, ModelState);
            }

            return Ok(actor);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteActor(int Id)
        {
            if (!_actor.ActorExists(Id)) 
                return NotFound();

            var actorToDelete = _actor.GetActor(Id);

            if ((!ModelState.IsValid))
                return BadRequest(ModelState);

            if (!_actor.DeleteActor(actorToDelete))
                ModelState.AddModelError("", "Something Went Wrong While Deleting This Actor");

            return NoContent();
        }

    }
}
