using App.Domain.Core.Entities;

namespace App.EndPoints.MVC.OnlineMarket.Models.ViewModels
{
    public class MultiModelViewModel
    {
        public List<Product> Products { get; set; } 
        public List<HomeAuctionViewModel> Auctions { get; set; } 
        public List<Stall> Stalls { get; set; } 
    }
}
