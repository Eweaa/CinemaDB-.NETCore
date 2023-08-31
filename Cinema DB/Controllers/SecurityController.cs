using Cinema_DB.Application.Actors.Queries;
using Cinema_DB.Application.Users.Queries;
using Cinema_DB.Helper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_DB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class SecurityController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<UserT>> GetUserQuery([FromQuery] GetUserQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
