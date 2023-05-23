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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<UserDto> GetUserByIdAsync(int UserId)
        {
            var Entity = await _dbContext.Users.FindAsync(UserId);
            return _mapper.Map<UserDto>(Entity);
        }

        public async Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var Entity = await _dbContext.Users.AsNoTracking().ToListAsync(cancellationToken);
            return _mapper.Map<List<UserDto>>(Entity);
        }

        public async Task AddUserAsync(UserDto User, CancellationToken cancellationToken)
        {
            var Entity = _mapper.Map<User>(User);
            _dbContext.Users.Add(Entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }



        public async Task UpdateUserAsync(UserDto User, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Users
                .Where(x => x.Id == User.Id)
                .FirstOrDefaultAsync();
            _mapper.Map(User, onerow);

            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteUserAsync(int UserId, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Users.FindAsync(UserId);
            if (onerow != null)
            {
                _dbContext.Users.Remove(onerow);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
