using Forum.Logic.Queries.Querys;
using Forum.Server.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ILogger<UserController> _logger, IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());

            if (users != null)
            {
                return Ok(users);
            }

            return BadRequest();
        }
    }
}
