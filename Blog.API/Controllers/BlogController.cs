using Blog.Application.Features.Blogs.Commands;
using Blog.Application.Features.Blogs.Queries;
using Blog.Application.Features.Blogs.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = new GetBlogsQuery();
            var response = await _mediator.Send(blogs);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            var response = await _mediator.Send(command);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBlogById(Guid id)
        {
            var query = new GetBlogByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            var response = await _mediator.Send(command);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBlog(Guid id)
        {
            var command = new RemoveBlogCommand { Id = id };
            var response = await _mediator.Send(command);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        [Route("ByCategory/{categoryId}")]
        public async Task<IActionResult> GetBlogsByCategoryId(Guid categoryId)
        {
            var query = new GetBlogsByCategoryIdQuery { CategoryId = categoryId };
            var response = await _mediator.Send(query);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
