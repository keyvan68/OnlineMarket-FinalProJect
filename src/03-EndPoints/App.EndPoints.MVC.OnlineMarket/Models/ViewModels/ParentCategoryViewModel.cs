using App.Domain.Core.DtoModels.ProductDtoModels;

namespace App.EndPoints.MVC.OnlineMarket.Models.ViewModels
{
    public class ParentCategoryViewModel
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }
        public string? ParentTitle { get; set; }
        public string Name { get; set; } = null!;

        public string? ImgUrl { get; set; }



        #region navigations

        public virtual List<ProductDto> Products { get; set; } = new List<ProductDto>();

        #endregion navigations
    }
}

