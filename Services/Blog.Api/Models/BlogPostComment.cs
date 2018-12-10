namespace Blog.Api.Models
{
    public class BlogPostComment
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public string Comment { get; set; }
    }
}
