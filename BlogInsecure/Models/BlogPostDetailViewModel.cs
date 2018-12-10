using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BlogInsecure.Models
{
    public class BlogPostDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        public string Comment { get; set; }
        public List<BlockPostCommentDto> BlockPostComments { get; set; }

        public class BlockPostCommentDto
        {
            public int Id { get; set; }
            public int BlogPostId { get; set; }
            public string Comment { get; set; }
        }
    }
}
