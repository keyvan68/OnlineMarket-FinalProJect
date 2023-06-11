using App.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام خریدار")]
        public string BuyerName { get; set; } = null!;
        [Display(Name = "نام فروشنده")]
        public string SellerName { get; set; } = null!;
        [Display(Name = "نام محصول")]
        public string? ProductName { get; set; } = null!;
        [Display(Name = "میزان فروش")]
        public int TotalAmount { get; set; }
        [Display(Name = "کمیسون سایت")]
        public int? Commision { get; set; }
        [Display(Name = "تعداد محصول")]
        public int Quantity { get; set; }


    }
}
