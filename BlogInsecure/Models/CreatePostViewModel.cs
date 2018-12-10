using System.ComponentModel.DataAnnotations;

namespace BlogInsecure.Models
{
    public class CreatePostViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
