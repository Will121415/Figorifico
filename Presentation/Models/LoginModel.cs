using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Entity;
namespace Presentation.Models
{
    public class LoginInputModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}