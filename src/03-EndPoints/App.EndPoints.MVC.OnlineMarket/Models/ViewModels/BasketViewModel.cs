namespace App.EndPoints.MVC.OnlineMarket.Models.ViewModels
{
    public class BasketViewModel
    {
        public List<BasketItemViewModel> Items { get; set; }
        public int TotalAmount { get; set; }

        public int BuyerId { get; set; }
        public string? BuyerName { get; set; }

        public int SellerId { get; set; }
        public string? SellerName { get; set; }
    }
}
