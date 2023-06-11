using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.DtoModels.UserDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class ApplicationUserApplicationService : IApplicationUserApplicationService
    {
        private readonly IProductRepository _productRepository;
        private readonly IAppUserRepository _appUserRepository;
        public ApplicationUserApplicationService(IProductRepository productRepository, IAppUserRepository appUserRepository)
        {
            _productRepository = productRepository;
            _appUserRepository = appUserRepository;
        }

        public async Task ConfirmByAdmin(int id)
        {
            await _productRepository.ConfirmByAdmin(id);
        }

        public async Task Delete(int productId, CancellationToken cancellationToken)
        {
            await _productRepository.Delete(productId, cancellationToken);
        }

        public async Task DeleteUser(int id, CancellationToken cancellationToken)
        {
            await _appUserRepository.DeleteUser(id, cancellationToken);
        }

        public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
        {
            var pruductlist = await _productRepository.GetAll(cancellationToken);
            return pruductlist;
        }

        public async Task<UpdateProductDto> GetById(int productId, CancellationToken cancellationToken)
        {
            var product= await _productRepository.GetById(productId,cancellationToken);
            return product;
        }

        public async Task<List<UserDto>> GetUserAll(CancellationToken cancellationToken)
        {
            var userList = await _appUserRepository.GetUserAll(cancellationToken);
            return userList;
        }

        public async Task<UserDto> GetUserById(int id, CancellationToken cancellationToken)
        {
            var user = await _appUserRepository.GetUserById(id, cancellationToken);
            return user;
        }

        public async Task SoftDelete(int productId, CancellationToken cancellationToken)
        {
            await _productRepository.SoftDelete(productId, cancellationToken);
        }

        public async Task Update(UpdateProductDto productDto, CancellationToken cancellationToken)
        {
            await _productRepository.Update(productDto, cancellationToken);
        }

        public async Task UpdateUser(UserDto entity, CancellationToken cancellationToken)
        {
            await _appUserRepository.UpdateUser(entity, cancellationToken);
        }
    }
}
