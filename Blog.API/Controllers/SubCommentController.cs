using Blog.Application.Features.SubComments.Commands;
using Blog.Application.Features.SubComments.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCommentController : ControllerBase
    {
        IMediator _mediator;

        public SubCommentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSubComments()
        {
            var query = new GetSubCommentsQuery();
            var response = await _mediator.Send(query);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubComment(CreateSubCommentCommand command)
        {
            var response = await _mediator.Send(command);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSubComment(UpdateSubCommentCommand command)
        {
            var response = await _mediator.Send(command);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSubComment(Guid id)
        {
            var command = new RemoveSubCommentCommand { Id = id };
            var response = await _mediator.Send(command);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> GetSubCommentsByCommentId(Guid id)
        {
            var query = new GetSubCommentByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
