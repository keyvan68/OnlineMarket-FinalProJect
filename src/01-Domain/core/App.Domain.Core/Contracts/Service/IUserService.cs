using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IUserService
    {
        Task AddUserAsync(UserDto User, CancellationToken cancellationToken);
        Task DeleteUserAsync(int UserId, CancellationToken cancellationToken);
        Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<UserDto> GetUserByIdAsync(int UserId);
        Task UpdateUserAsync(UserDto User, CancellationToken cancellationToken);
    }
}
