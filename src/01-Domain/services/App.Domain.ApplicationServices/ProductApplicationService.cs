using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels;
using App.Domain.Core.DtoModels.ImageDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using Microsoft.AspNetCore.Http;
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
        private readonly IImageRepository _imageRepository;


        public ProductApplicationService(IProductRepository productRepository, IImageRepository imageRepository)
        {
            _productRepository = productRepository;
            _imageRepository = imageRepository;
        }

        public  async Task ConfirmByAdmin(int id)
        {
            await _productRepository.ConfirmByAdmin(id);
        }

        public async Task<int> Create(CreateProductDto productDtos, CancellationToken cancellationToken)
        {
            productDtos.CreatedAt = DateTime.Now;
            productDtos.IsAccepted = false;
            productDtos.IsActive = false;
            var id = await _productRepository.Create(productDtos, cancellationToken);

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
        public async Task<List<ProductDto>> GetAllWithOutAuction(CancellationToken cancellationToken)
        {
            var pruductlist = (await _productRepository.GetAll(cancellationToken))
                .Where(a=>a.Auction ==false && a.IsAccepted == true)
                .OrderByDescending(a=>a.Id)
                .ToList(); 

            return pruductlist;
        }


        public async Task<List<ProductDto>> GetAllWithAuctionBySellerId(int sellerId, CancellationToken cancellationToken)
        {
            var pruductlist = await _productRepository.GetAllWithAuctionBySellerId(sellerId, cancellationToken);

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

        public async Task<UpdateProductDto> GetById(int productId, CancellationToken cancellationToken)
        {
            var product= await _productRepository.GetById(productId, cancellationToken);
            return product;
        }

        public async Task<List<ProductDto>> GetBySeller(int sellerId, CancellationToken cancellationToken)
        {
            var pruductlist = await _productRepository.GetBySeller(sellerId, cancellationToken);

            return pruductlist;
        }

        public async Task<List<ProductDto>> GetByStall(int stallId, CancellationToken cancellationToken)
        {
            var product= await _productRepository.GetByStall(stallId, cancellationToken);
            return product;
        }

        public async Task SoftDelete(int productId, CancellationToken cancellationToken)
        {
            await _productRepository.SoftDelete(productId, cancellationToken);
        }

        public async Task Update(UpdateProductDto productDto, CancellationToken cancellationToken)
        {
            await _productRepository.Update(productDto, cancellationToken);
        }
        public async Task UploadImageProduct(int productId,IFormFile file, string rootpath ,CancellationToken cancellationToken)
        {
            var filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
            var path = Path.Combine(rootpath, @"Images\Product", filename);
            using (var stream = File.Create(path))
            {
                file.CopyTo(stream);
            }
            var imageDto = new ImageDto()
            {
               Name=filename,
               Url= @"\Images\Product\" + filename,
               ProductId=productId,
               CreatedAt=DateTime.Now,
            };
            await _imageRepository.CreateImage(imageDto, cancellationToken);
        }

        public async Task<ProductDtoSeller> GetSellerIdByProductId(int id, CancellationToken cancellationToken)
        {
            var seller=  await _productRepository.GetSellerIdByProductId(id, cancellationToken);
            return seller;
        }
        public async Task ReduceQuantityProduct(int countOfProducts, int productId, CancellationToken cancellationToken)
        {
            //get product
            var productDto = await _productRepository.GetById(productId, cancellationToken);
            if (productDto is not null)
            {
                productDto.NumberofProducts = productDto.NumberofProducts- countOfProducts;
                //update product
                await _productRepository.Update(productDto, cancellationToken);
            }
        }
    }
}
