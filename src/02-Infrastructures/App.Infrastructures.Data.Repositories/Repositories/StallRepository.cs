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
    public class StallRepository : IStallRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public StallRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<StallDto> GetStallByIdAsync(int stallId)
        {
            var stall = await _dbContext.Stalls.FindAsync(stallId);
            return _mapper.Map<StallDto>(stall);
        }

        public async Task<List<StallDto>> GetAllStallsAsync(CancellationToken cancellationToken)
        {
            var stalls = await _dbContext.Stalls.AsNoTracking().ToListAsync(cancellationToken);
            return _mapper.Map<List<StallDto>>(stalls);
        }

        public async Task AddStallAsync(StallDto stall, CancellationToken cancellationToken)
        {
            var stallEntity = _mapper.Map<Stall>(stall);
            _dbContext.Stalls.Add(stallEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }



        public async Task UpdateStallAsync(StallDto stall, CancellationToken cancellationToken)
        {
            var onerow = await _dbContext.Stalls
                .Where(x => x.Id == stall.Id)
                .FirstOrDefaultAsync();
            _mapper.Map(stall, onerow);

            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteStallAsync(int stallId, CancellationToken cancellationToken)
        {
            var stall = await _dbContext.Stalls.FindAsync(stallId);
            if (stall != null)
            {
                _dbContext.Stalls.Remove(stall);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
