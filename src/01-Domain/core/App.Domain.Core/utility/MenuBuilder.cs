using App.Domain.Core.DtoModels.CategoryDtoModels;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.utility
{
    public class MenuBuilder
    {
        public static string BuildMenu(List<Category> categories)
        {
            string menuHtml = "<ul>";

            foreach (var category in categories)
            {
                if (category.ParentId == null)
                {
                    menuHtml += "<li><a href='" + category.Name + "'>" + category.Name + "</a>";
                    menuHtml += BuildSubMenu(category, categories);
                    menuHtml += "</li>";
                }
            }

            menuHtml += "</ul>";

            return menuHtml;
        }

        public static string BuildSubMenu(Category category, List<Category> categories)
        {
            string subMenuHtml = "<ul>";

            var subCategories = categories.Where(c => c.ParentId == category.Id).ToList();

            foreach (var subCategory in subCategories)
            {
                subMenuHtml += "<li><a href='" + subCategory.Name + "'>" + subCategory.Name + "</a>";
                subMenuHtml += BuildSubMenu(subCategory, categories);
                subMenuHtml += "</li>";
            }

            subMenuHtml += "</ul>";

            return subMenuHtml;
        }
    }
}
