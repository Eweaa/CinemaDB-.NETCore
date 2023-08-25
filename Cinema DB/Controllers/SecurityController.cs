using Cinema_DB.Application.Actors.Queries;
using Cinema_DB.Application.Users.Queries;
using Cinema_DB.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_DB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class SecurityController : ApiControllerBase
    {
        //private readonly IUser _user;
        //public SecurityController(IUser user)
        //{
        //    _user = user;
        //}

        //    [HttpGet]
        //    public dynamic Login(string userName, string password)
        //    {
        //        var userExist = _user.UserExists(userName);
        //        var user = _user.GetUser(userName);

        //        if (!userExist)
        //        {
        //            return "This User Does Not Exist";
        //        }

        //        if(user.Name == userName && user.Password == password)
        //        {
        //            return Tuple.Create(user.Role, JWTTokenGenerator.Generate(userName, password));
        //            //return JWTTokenGenerator.Generate(userName, password);
        //        }

        //        if(user.Name == userName && user.Password != password)
        //        {
        //            return "You've Entered An Incorrect Password";
        //        }
        //        return "what happened";
        //    }
        [HttpGet]
        public async Task<ActionResult<string>> GetUserQuery([FromQuery] GetUserQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
