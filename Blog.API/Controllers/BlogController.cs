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
    }
}
