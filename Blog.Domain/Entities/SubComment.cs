using Blog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class SubComment : BaseEntity
    {
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
