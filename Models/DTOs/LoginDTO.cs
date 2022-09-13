using System.ComponentModel.DataAnnotations;

namespace AuthenticationAndAuthorization.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Please type into user name")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please type into password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
