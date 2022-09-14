using AuthenticationAndAuthorization.Models.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationAndAuthorization.Models.DTOs
{
    public class UserUpdateDTO
    {
        [Required(ErrorMessage ="Must to type into user name")]
        [Display(Name ="User Name")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Must to type into password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Must to type into email adree")]
        [Display(Name = "Email Adress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public UserUpdateDTO(){}
        public UserUpdateDTO(AppUser appUser)
        {
            UserName = appUser.UserName;
            Password = appUser.PasswordHash;
            Email = appUser.Email;
        }
    }
}
