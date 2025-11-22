using Blog.Application.Base;
using Blog.Application.Features.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.Application.Features.Categories.Results;
using Blog.Application.Features.Categories.Commands;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var query = new GetCategoryQuery();
            var response = await _mediator.Send(query);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCategory(CreateCategoryCommands command)
        {
            var response = await _mediator.Send(command);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var query = new GetCategoryByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var command = new RemoveCategoryCommand { Id = id };
            var response = await _mediator.Send(command);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
