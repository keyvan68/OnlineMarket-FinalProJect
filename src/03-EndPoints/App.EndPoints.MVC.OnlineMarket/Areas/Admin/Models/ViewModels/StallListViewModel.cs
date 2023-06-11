using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Admin.Models.ViewModels
{
    public class StallListViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام مغازه")]
        public string Name { get; set; } = null!;
        [Display(Name = "نام فروشنده")]
        public string? SellerName { get; set; }

        [Display(Name = "لیست محصولات")]
        public List<Product> Products { get; set; } = new List<Product>();
    }

   
}
