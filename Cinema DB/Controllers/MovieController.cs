using Cinema_DB.Application.Movies.Commands.CreateMovie;
using Cinema_DB.Application.Movies.Commands.DeleteMovie;
using Cinema_DB.Application.Movies.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_DB.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ApiControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<MovieDto>>> GetMovieListQuery([FromQuery] GetMovieListQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<MovieDto>> GetMovie([FromQuery] GetMovieQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateMovieCommand command)
        {
            return await Mediator.Send(command);
        }


        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(long Id)
        {
            await Mediator.Send(new DeleteMovieCommand(Id));
            return NoContent();
        }

    }
}
