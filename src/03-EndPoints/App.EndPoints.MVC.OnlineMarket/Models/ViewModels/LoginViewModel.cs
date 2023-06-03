using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.EndPoints.MVC.OnlineMarket.Models.ViewModels
{
    public class LoginViewModel
    {
        //[Required]
        //[EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        [Display(Name = "پاسورد")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
