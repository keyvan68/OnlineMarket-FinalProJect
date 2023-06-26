using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Models.ViewModels
{
    public class CreateStallViewModel
    {
        
        [Display(Name ="نام فروشگاه")]
        [Required(ErrorMessage ="نام فروشگاه نمیتواند خالی باشد")]
        public string Name { get; set; } 

        [Display(Name = "توشیحات")]
        public string Description { get; set; } 

        [Display(Name = "ادرس")]
        public string Address { get; set; } 
        public int SellerId { get; set; }
    }
}
