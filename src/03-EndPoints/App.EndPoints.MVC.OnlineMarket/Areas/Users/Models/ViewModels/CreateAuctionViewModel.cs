using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Models.ViewModels
{
    public class CreateAuctionViewModel
    {
        public int SellerId { get; set; }

        public int ProductId { get; set; }
        [Display(Name ="زمان شروع")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "زمان پایان")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "قسمت پیشنهادی")]
        public int HighestBid { get; set; }

        public bool DeactiveProduct { get; set; }
    }
}
