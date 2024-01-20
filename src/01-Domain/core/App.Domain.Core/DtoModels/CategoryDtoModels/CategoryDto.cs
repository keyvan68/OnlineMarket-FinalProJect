using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.DtoModels.CategoryDtoModels
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }
        public string? ParentName { get; set; }

        public string Name { get; set; } = null!;

        public string? ImgUrl { get; set; }
        //public IFormFile? Image { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; }


        public virtual ICollection<CategoryDto> SubCategories { get; set; } = new List<CategoryDto>();
        #region Navigation
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        #endregion

    }
}
