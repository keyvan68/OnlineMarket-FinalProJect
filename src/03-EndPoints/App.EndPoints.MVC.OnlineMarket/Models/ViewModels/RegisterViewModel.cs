using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.EndPoints.MVC.OnlineMarket.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور و تأیید رمز عبور  مطابقت ندارند.")]
        [Display(Name = "تأیید رمز عبور")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string? Role { get; set; }
    }
}
