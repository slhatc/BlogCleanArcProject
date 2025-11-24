using Blog.Application.Base;
using Blog.Application.Features.Blogs.Results;
using Blog.Application.Features.Users.Results;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Results
{
    public class GetCommentsQueryResult : BaseDto
    {
        public string UserId { get; set; }
        public GetUsersQueryResult User { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        //public virtual IList<SubComment> SubComments { get; set; }
        public Guid BlogId { get; set; }
        public GetBlogsQueryResult Blog { get; set; }
    }
}
