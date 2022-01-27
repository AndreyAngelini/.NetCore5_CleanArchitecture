using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [Required()]
        [EmailAddress()]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required()]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password don´t match.")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
