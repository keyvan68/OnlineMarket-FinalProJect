using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.UserDtoModels;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AppUserRepository(AppDbContext context,IMapper mapper)
        {
            
            _context = context;
            _mapper = mapper;
        }
       

        public async Task<List<UserDto>> GetUserAll(CancellationToken cancellationToken)
        {
            var records = await _context.Users
                .Where(u => u.IsDeleted == false)
                .Select(u => new UserDto()
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber
                }).ToListAsync(cancellationToken);
            
            return records;
        }

        public async Task<UserDto> GetUserById(int id, CancellationToken cancellationToken)
        {
            var record = await _context.Users
                .Where(u => u.Id == id).FirstOrDefaultAsync(cancellationToken);
            return _mapper.Map<UserDto>(record);
        }

        public async Task UpdateUser(UserDto entity, CancellationToken cancellationToken)
        {
            var record = await _context.Users
                .Where(u => u.Id == entity.Id).FirstOrDefaultAsync(cancellationToken);
            _mapper.Map(entity, record);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteUser(int id, CancellationToken cancellationToken)
        {
            var record = await _context.Users
                .Where(u => u.Id == id).FirstOrDefaultAsync(cancellationToken);
            record.IsDeleted = true;
            record.DeletedAt = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
