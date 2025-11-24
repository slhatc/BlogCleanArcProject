using Blog.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Categories.Commands
{
    public class CreateCategoryCommands : IRequest<BaseResult<object>>
    {
        public string CategoryName { get; set; }
    }
}
