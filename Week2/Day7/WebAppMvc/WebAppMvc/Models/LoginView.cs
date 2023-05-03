using Microsoft.Build.Framework;

namespace WebAppMvc.Models
{
    public class LoginView
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
