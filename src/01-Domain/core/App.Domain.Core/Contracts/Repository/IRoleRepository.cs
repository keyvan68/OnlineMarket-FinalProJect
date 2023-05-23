using App.Domain.Core.DtoModels;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IRoleRepository
    {
        Task AddRoleAsync(RoleDto Role, CancellationToken cancellationToken);
        Task DeleteRoleAsync(int RoleId, CancellationToken cancellationToken);
        Task<List<RoleDto>> GetAllRolesAsync(CancellationToken cancellationToken);
        Task<RoleDto> GetRoleByIdAsync(int RoleId);
        Task UpdateRoleAsync(RoleDto Role, CancellationToken cancellationToken);
    }
}