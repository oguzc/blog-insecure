using System.ComponentModel.DataAnnotations;

namespace BlogInsecure.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
