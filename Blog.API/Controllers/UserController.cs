using Blog.Application.Features.Users.Commands;
using Blog.Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(GetLoginQuery query)
        {
            var response = await _mediator.Send(query);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
