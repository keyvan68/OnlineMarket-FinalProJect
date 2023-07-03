using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.EndPoints.MVC.OnlineMarket.Models.ViewModels
{
    public class BidViewModel
    {
        public int Id { get; set; }

        public int BuyerId { get; set; }

        public int AuctionId { get; set; }

        [Required(ErrorMessage = "وارد  کردن {0} اجباری است ")]
        [Display(Name = "قیمت پیشنهادی")]
        public int Price { get; set; }
    }
}
