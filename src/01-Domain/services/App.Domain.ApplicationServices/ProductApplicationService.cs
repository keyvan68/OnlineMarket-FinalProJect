using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repositorys;
using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductRepository _productRepository;

        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public  async Task ConfirmByAdmin(int id)
        {
            await _productRepository.ConfirmByAdmin(id);
        }

        public async Task<int> Create(ProductDto productDto, CancellationToken cancellationToken)
        {
            var id = await _productRepository.Create(productDto, cancellationToken);
            return id;
        }

        public async Task Delete(int productId, CancellationToken cancellationToken)
        {
            await _productRepository.Delete(productId, cancellationToken);
        }

        public async Task<List<ProductDto>> GetAcceptedProducts(CancellationToken cancellationToken)
        {
            var pruductlist= await _productRepository.GetAcceptedProducts(cancellationToken);
            return pruductlist;
        }

        public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
        {
           var pruductlist =  await _productRepository.GetAll(cancellationToken);
            return pruductlist;
        }

        public async Task<List<ProductDto>> GetByBuyer(int buyerId, CancellationToken cancellationToken)
        {
          var productbuyer=  await _productRepository.GetByBuyer(buyerId, cancellationToken);
            return productbuyer;
        }

        public async Task<List<ProductDto>> GetByCategory(int categoryId, CancellationToken cancellationToken)
        {
            var productcategory= await _productRepository.GetByCategory(categoryId, cancellationToken);
            return productcategory;
        }

        public async Task<ProductDto> GetById(int productId, CancellationToken cancellationToken)
        {
            var product= await _productRepository.GetById(productId, cancellationToken);
            return product;
        }

        public async Task<List<ProductDto>> GetByStall(int stallId, CancellationToken cancellationToken)
        {
            var product= await _productRepository.GetByStall(stallId, cancellationToken);
            return product;
        }

        public async Task Update(ProductDto productDto, CancellationToken cancellationToken)
        {
            await _productRepository.Update(productDto, cancellationToken);
        }
    }
}
