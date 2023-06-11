using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels
{
    public class UserViewModels
    {
        public int Id { get; set; }

        
        [Display(Name = "نام کاربری")]
        public string? UserName { get; set; } = string.Empty;

        
        [Display(Name = " ایمیل")]
        public string? Email { get; set; } = string.Empty;

        
        [Display(Name = "شماره موبایل")]
        public string? PhoneNumber { get; set; }
    }
}
