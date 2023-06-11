using App.Domain.Core.DtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.DtoModels.UserDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.ApplicationService
{
    public interface IApplicationUserApplicationService
    {
        Task<List<ProductDto>> GetAll(CancellationToken cancellationToken);
        Task ConfirmByAdmin(int id);
        Task Delete(int productId, CancellationToken cancellationToken);
        Task Update(UpdateProductDto productDto, CancellationToken cancellationToken);
        Task<UpdateProductDto> GetById(int productId, CancellationToken cancellationToken);
        Task SoftDelete(int productId, CancellationToken cancellationToken);
        Task<List<UserDto>> GetUserAll(CancellationToken cancellationToken);

        Task<UserDto> GetUserById(int id, CancellationToken cancellationToken);
        Task UpdateUser(UserDto entity, CancellationToken cancellationToken);
        Task DeleteUser(int id, CancellationToken cancellationToken);

    }
}
