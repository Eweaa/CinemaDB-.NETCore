using AutoMapper;
using Cinema_DB.Application.Actors.Commands.CreateActor;
using Cinema_DB.Application.Actors.Commands.DeleteActor;
using Cinema_DB.Business.Interfaces;
using Cinema_DB.Domain.Entities;
using Cinema_DB.Helper.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ApiControllerBase
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
        public async Task<ActionResult<long>> Create(CreateActorCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(long Id)
        {
            await Mediator.Send(new DeleteActorCommand(Id));
            return NoContent();
        }

    }
}
