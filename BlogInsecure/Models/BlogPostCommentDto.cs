﻿namespace BlogInsecure.Models
{
    public class BlogPostCommentDto
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public string Comment { get; set; }
    }
}
