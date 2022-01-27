using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "Invalid format e-mail")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "The password must be least {2} and at max {1} characters long.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }

    }
}
