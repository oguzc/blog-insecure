using System.Collections.Generic;

namespace Blog.Api.Models
{
    public class BlogPostDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<BlogPostComment> BlockPostComments { get; set; }
    }
}
