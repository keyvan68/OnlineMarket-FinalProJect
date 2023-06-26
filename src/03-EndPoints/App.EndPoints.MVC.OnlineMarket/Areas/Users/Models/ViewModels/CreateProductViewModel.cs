using App.Domain.Core.DtoModels.CategoryDtoModels;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.OnlineMarket.Areas.Users.Models.ViewModels
{
    public class CreateProductViewModel
    {
        [Display(Name = "نام محصول")]
        public string Title { get; set; }
        [Display(Name = "قیمت")]
        public int Price { get; set; }
        [Display(Name = "توضیحات محصول")]
        public string Description { get; set; }
        [Display(Name = "تعداد ")]
        public int NumberofProducts { get; set; }
        public int StallId { get; set; }
        [Display(Name = "دسته بندی ")]
        public int CategoryId { get; set; }
        [Display(Name = "مزایده ")]
        public bool Auction { get; set; }
        public DateTime? CreatedAt { get; set; }
        public List<CategoryDto> Categories { get; set; }
        [Display(Name = "تصویر ")]
        public IFormFile ImageFile { get; set; }
    }
}
