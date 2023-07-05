using App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels;

namespace App.EndPoints.MVC.OnlineMarket.Models.ViewModels
{
    public class BasketItemViewModel
    {
        
        public ProductBasketViewModel Product { get; set; }
        public int CountOfProducts { get; set; }
    }
}
