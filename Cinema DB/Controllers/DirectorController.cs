using Cinema_DB.Application.Directors.Commands.CreateDirector;
using Cinema_DB.Application.Directors.Commands.DeleteDirector;
using Cinema_DB.Application.Directors.Queries;
using Cinema_DB.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ApiControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<Director>>> GetDirectorListQuery([FromQuery] GetDirectorListQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<Director>> GetDirectorQuery([FromQuery] GetDirectorQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateDirectorCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(long Id)
        {
            await Mediator.Send(new DeleteDirectorCommand(Id));
            return NoContent();
        }
    }
}
