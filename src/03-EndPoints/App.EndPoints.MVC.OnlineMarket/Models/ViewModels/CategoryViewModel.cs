using App.Domain.Core.DtoModels.CategoryDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;

namespace App.EndPoints.MVC.OnlineMarket.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }
        public string? ParentTitle { get; set; }

        public string Name { get; set; } 
        public string? ImageUrl { get; set; }

        public virtual ICollection<CategoryDto> SubCategories { get; set; } = new List<CategoryDto>();

        #region navigations

        public virtual List<ProductDto> Products { get; set; } = new List<ProductDto>();

        #endregion navigations
    }
}
