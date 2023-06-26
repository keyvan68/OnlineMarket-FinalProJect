using App.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels
{
    public class ProductViewModel
    {

        public int Id { get; set; }

        [Display(Name = "نام محصول")]
        public string Title { get; set; } = null!;
        [Display(Name = "دسته بندی")]
        public string? CategoryName { get; set; }
        [Display(Name = "نام فروشنده")]
        public string? SellerName { get; set; }
        [Display(Name = "نام فروشگاه")]
        public string? StallName { get; set; }
        [Display(Name = "تعداد محصول")]
        public int NumberofProducts { get; set; }
        [Display(Name = "تایید محصول")]
        public bool IsAccepted { get; set; }

        [Display(Name = "محصول مزایده ای")]
        public bool Auction { get; set; }

        [Display(Name = "قیمت محصول (تومان)")]
        public int Price { get; set; }
        public virtual List<Auction> Auctions { get; set; } = new List<Auction>();
    }
}
