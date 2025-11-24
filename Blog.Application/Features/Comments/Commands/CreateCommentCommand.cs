using Blog.Application.Base;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Commands
{
    public class CreateCommentCommand : IRequest<BaseResult<object>>
    {
        public string UserId { get; set; }
        public string Content { get; set; }
        [JsonIgnore]
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public Guid BlogId { get; set; }
    }
}
