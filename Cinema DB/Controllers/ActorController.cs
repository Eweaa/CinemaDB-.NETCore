//using Cinema_DB.Application.Actors.Commands.CreateActor;
//using Cinema_DB.Application.Actors.Commands.DeleteActor;
//using Cinema_DB.Application.Actors.Queries;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cinema_DB.Application.ActorsNS.Queries;

namespace Cinema_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ActorDto>>> GetActorListQuery([FromQuery] GetActorListQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ActorDto>> GetActor([FromQuery] GetActorQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateActorCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(long Id)
        {
            await Mediator.Send(new DeleteActorCommand(Id));
            return NoContent();
        }

    }
}
