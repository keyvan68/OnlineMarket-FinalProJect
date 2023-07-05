using App.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels
{
    public class UpdateProductVM
    {
        public int Id { get; set; }

        [Display(Name = "نام محصول")]
        public string Title { get; set; } = null!;
        
        [Display(Name = "تعداد محصول")]
        public int NumberofProducts { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; } = null!;
        [Display(Name = "تایید محصول")]
        public bool IsAccepted { get; set; }
        [Display(Name = "محصول مزایده ای")]
        public bool Auction { get; set; }

        [Display(Name = "قیمت محصول (تومان)")]
        public int Price { get; set; }
        [Display(Name = "تصویر ")]
        public IFormFile ImageFile { get; set; }

    }
}
