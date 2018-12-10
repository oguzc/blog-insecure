using System.ComponentModel.DataAnnotations;

namespace BlogInsecure.Models
{
    public class BlogPostDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
