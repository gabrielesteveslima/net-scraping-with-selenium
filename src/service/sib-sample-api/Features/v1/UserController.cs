namespace SibSample.API.Features.v1
{
    using Application.Users;
    using Application.Users.RegisterUser;
    using Configuration.ProblemDetails.Helpers;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Application.Users.GetUsers;

    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/users")]
    [Produces("application/json")]
    [ServiceFilter(typeof(ProblemDetailsFilter))]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserContract request)
        {
            return Created("",
                await _mediator.Send(new RegisterUserCommand(request)));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _mediator.Send(new GetUsersQuery()));
        }
    }
}