using Blog.Application.Base;
using Blog.Application.Features.Comments.Results;
using Blog.Application.Features.Users.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Results
{
    public class GetSubCommentByIdQueryResult : BaseDto
    {
        public string UserId { get; set; }
        public GetUsersQueryResult User { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid CommentId { get; set; }
        public GetCommentsQueryResult Comment { get; set; }
    }
}
