using App.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Models.ViewModels
{
    public class AuctionViewModel
    {
        public int Id { get; set; }

        //public int SellerId { get; set; }

        //public int ProductId { get; set; }
        [Display(Name ="نام فروشگاه")]
        public string StallName { get; set; }
        [Display(Name = "نام فروشنده")]
        public string SellerName { get; set; }
        [Display(Name = "نام محصول")]
        public string ProductName { get; set; }
        [Display(Name = "شروع ")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "پایان")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "بالاترین پیشنهاد")]
        public int HighestBid { get; set; }

        //public bool DeactiveProduct { get; set; }



        //public bool IsDeleted { get; set; }


        public  List<Bid> Bids { get; set; } = new List<Bid>();

        //public virtual Seller Seller { get; set; } = null!;

        //public virtual Product Product { get; set; } = null!;
    }
}
