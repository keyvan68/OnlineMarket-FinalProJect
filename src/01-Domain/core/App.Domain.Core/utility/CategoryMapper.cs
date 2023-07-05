using App.Domain.Core.DtoModels.CategoryDtoModels;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.utility
{
    public class CategoryMapper
    {
        public static List<Category> MapCategories(List<CategoryDto> categoriesDTO)
        {
            List<Category> categories = new List<Category>();

            foreach (var categoryDTO in categoriesDTO)
            {
                var category = new Category
                {
                    Id = categoryDTO.Id,
                    Name = categoryDTO.Name,
                    ParentId = categoryDTO.ParentId,
                    CreatedAt = categoryDTO.CreatedAt,
                    LastModifiedAt = categoryDTO.LastModifiedAt,
                    DeletedAt = categoryDTO.DeletedAt
                };

                categories.Add(category);
            }

            return categories;
        }
    }
}
