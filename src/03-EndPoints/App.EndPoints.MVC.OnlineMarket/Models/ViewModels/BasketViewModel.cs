using App.Domain.Core.Entities;

namespace App.EndPoints.MVC.OnlineMarket.Models.ViewModels
{
    public class BasketViewModel
    {
        public int TotalAmount { get; set; }

        public int BuyerId { get; set; }
        public string? BuyerName { get; set; }

        public int SellerId { get; set; }
        public string? SellerName { get; set; }

        public  Buyer Buyer { get; set; } = null!;

        public  Seller Seller { get; set; } = null!;

        public  ICollection<InvoiceProduct> InvoiceProducts { get; set; } = new List<InvoiceProduct>();
    }
}
