using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.CategoryDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class CategoryApplicationService : ICategoryApplicationService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApplicationService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Create(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.Create(categoryDto, cancellationToken);
            return list;
        }

        public async Task Delete(int categoryId, CancellationToken cancellationToken)
        {
             await _categoryRepository.Delete(categoryId, cancellationToken);
        }

        public async Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetAll(cancellationToken);
                return list;
        }
        public async Task<List<CategoryDto>> GetAllParentForMenu(CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll(cancellationToken);
            categories.Where(c => c.ParentId is null).ToList();
            foreach (var category in categories)
            {
                await GetSubCategoriesRecursive(category, cancellationToken);
            }
            return categories;

        }
        public async Task<List<CategoryDto>> GetAllParent(CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll(cancellationToken);
            return categories.Where(c => c.ParentId is null).ToList();
            

        }
        private async Task GetSubCategoriesRecursive(CategoryDto category, CancellationToken cancellationToken)
        {
            //subCategories related to the same category
            category.SubCategories = (await _categoryRepository.GetAll(cancellationToken)).Where(c => c.ParentId == category.Id).ToList();

            foreach (var subCategory in category.SubCategories)
            {
                await GetSubCategoriesRecursive(subCategory, cancellationToken);
            }
        }

        public async Task<CategoryDto> GetById(int categoryId, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetById(categoryId, cancellationToken);
                return list;
        }

        public async Task<CategoryDto> GetParentCategory(int categoryId, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetParentCategory(categoryId, cancellationToken);
                return list;
        }

        public async Task<List<ProductDto>> GetProducts(int categoryId, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetProducts(categoryId, cancellationToken);
                return list;
        }

        public async Task<List<CategoryDto>> GetSubcategories(int categoryId, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetSubcategories(categoryId, cancellationToken);
                return list;
        }

        public async Task Update(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            await _categoryRepository.Update(categoryDto, cancellationToken);
        }
    }
}
