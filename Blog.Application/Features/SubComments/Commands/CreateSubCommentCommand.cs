using Blog.Application.Base;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Commands
{
    public class CreateSubCommentCommand : IRequest<BaseResult<object>>
    {
        public string UserId { get; set; }
        public string Content { get; set; }
        [JsonIgnore]
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public Guid CommentId { get; set; }
    }
}
