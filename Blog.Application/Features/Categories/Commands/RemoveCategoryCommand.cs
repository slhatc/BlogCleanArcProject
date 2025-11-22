using Blog.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Categories.Commands
{
    public class RemoveCategoryCommand : IRequest<BaseResult<bool>>
    {
        public Guid Id { get; set; }
    }
}
