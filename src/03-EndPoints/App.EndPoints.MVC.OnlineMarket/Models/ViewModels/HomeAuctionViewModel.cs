using App.Domain.Core.Entities;

namespace App.EndPoints.MVC.OnlineMarket.Models.ViewModels
{
    public class HomeAuctionViewModel
    {
        public int Id { get; set; }
        public int CountOfProducts { get; set; }
        public int Price { get; set; }
        public List<Image> ProductImages { get; set; }
        public string SellerName { get; set; }
        public string StoreTitle { get; set; }
        public string ProductTitle { get; set; }
    }
}
