using App.Domain.Core.DtoModels.UserDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IAppUserRepository
    {
        Task<List<UserDto>> GetUserAll(CancellationToken cancellationToken);

        Task<UserDto> GetUserById(int id, CancellationToken cancellationToken);
        Task UpdateUser(UserDto entity, CancellationToken cancellationToken);
        Task DeleteUser(int id, CancellationToken cancellationToken);


    }
}
