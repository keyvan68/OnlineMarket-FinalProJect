using App.Domain.Core.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.Service
{
    public interface IRoleService
    {
        Task AddRoleAsync(RoleDto Role, CancellationToken cancellationToken);
        Task DeleteRoleAsync(int RoleId, CancellationToken cancellationToken);
        Task<List<RoleDto>> GetAllRolesAsync(CancellationToken cancellationToken);
        Task<RoleDto> GetRoleByIdAsync(int RoleId);
        Task UpdateRoleAsync(RoleDto Role, CancellationToken cancellationToken);
    }
}
