using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        //private readonly AppDbContext _dbContext;
        //private readonly IMapper _mapper;

        //public RoleRepository(AppDbContext dbContext, IMapper mapper)
        //{
        //    _dbContext = dbContext;
        //    _mapper = mapper;
        //}


        //public async Task<RoleDto> GetRoleByIdAsync(int RoleId)
        //{
        //    var Entity = await _dbContext.Roles.FindAsync(RoleId);
        //    return _mapper.Map<RoleDto>(Entity);
        //}

        //public async Task<List<RoleDto>> GetAllRolesAsync(CancellationToken cancellationToken)
        //{
        //    var Entity = await _dbContext.Roles.AsNoTracking().ToListAsync(cancellationToken);
        //    return _mapper.Map<List<RoleDto>>(Entity);
        //}

        //public async Task AddRoleAsync(RoleDto Role, CancellationToken cancellationToken)
        //{
        //    var Entity = _mapper.Map<Role>(Role);
        //    _dbContext.Roles.Add(Entity);
        //    await _dbContext.SaveChangesAsync(cancellationToken);
        //}



        //public async Task UpdateRoleAsync(RoleDto Role, CancellationToken cancellationToken)
        //{
        //    var onerow = await _dbContext.Roles
        //        .Where(x => x.Id == Role.Id)
        //        .FirstOrDefaultAsync();
        //    _mapper.Map(Role, onerow);

        //    await _dbContext.SaveChangesAsync(cancellationToken);

        //}

        //public async Task DeleteRoleAsync(int RoleId, CancellationToken cancellationToken)
        //{
        //    var onerow = await _dbContext.Roles.FindAsync(RoleId);
        //    if (onerow != null)
        //    {
        //        _dbContext.Roles.Remove(onerow);
        //        await _dbContext.SaveChangesAsync(cancellationToken);
        //    }
        //}
    }
}
