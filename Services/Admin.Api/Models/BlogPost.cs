using System.ComponentModel.DataAnnotations;

namespace Admin.Api.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
