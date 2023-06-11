using App.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        [Display(Name ="نام خریدار")]
        public string BuyerName { get; set; } = null!;
        [Display(Name = "نام فروشنده")]
        public string SellerName { get; set; } = null!;
        [Display(Name = "نام محصول")]
        public string? ProductName { get; set; } = null!;
        [Display(Name = "بدنه کامنت")]
        public string Description { get; set; } = null!;
        [Display(Name = "تایید شده")]
        public bool? IsAccepted { get; set; }
       
    }
}
