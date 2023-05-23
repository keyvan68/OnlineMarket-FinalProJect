using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IUserRepository
    {
        Task AddUserAsync(UserDto User, CancellationToken cancellationToken);
        Task DeleteUserAsync(int UserId, CancellationToken cancellationToken);
        Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<UserDto> GetUserByIdAsync(int UserId);
        Task UpdateUserAsync(UserDto User, CancellationToken cancellationToken);
    }
}