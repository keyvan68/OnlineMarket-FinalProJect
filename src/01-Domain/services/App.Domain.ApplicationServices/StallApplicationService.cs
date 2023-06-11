﻿using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels;
using App.Domain.Core.DtoModels.StallDtoModels;
using App.Domain.Core.DtoModels.ProductDtoModels;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class StallApplicationService : IStallApplicationService
    {
        private readonly IStallRepository _stallRepository;

        public StallApplicationService(IStallRepository stallRepository)
        {
            _stallRepository = stallRepository;
        }

        public async Task<int> CreateStall(StallDto stallDto, CancellationToken cancellationToken)
        {
            var stallid= await _stallRepository.CreateStall(stallDto, cancellationToken);
            return stallid;
        }

        public async Task DeleteStall(int stallId, CancellationToken cancellationToken)
        {
             await _stallRepository.DeleteStall(stallId, cancellationToken);
            
        }

        public async Task<List<StallDto>> GetAllStalls(CancellationToken cancellationToken)
        {
            var stall = await _stallRepository.GetAllStalls(cancellationToken);
            return stall;
        }

        public async Task<UpdateStallDto> GetStallById(int stallId, CancellationToken cancellationToken)
        {
            var stallid = await _stallRepository.GetStallById(stallId,cancellationToken);
            return stallid;
        }

        public async Task<List<ProductDto>> GetStallProducts(int stallId, CancellationToken cancellationToken)
        {
            var stallproduct = await _stallRepository.GetStallProducts(stallId, cancellationToken);
            return stallproduct;
        }

        public async Task SoftDelete(int stallId, CancellationToken cancellationToken)
        {
            await _stallRepository.SoftDelete(stallId, cancellationToken);
        }

        public async Task UpdateStall(UpdateStallDto stallDto, CancellationToken cancellationToken)
        {
           await _stallRepository.UpdateStall(stallDto,cancellationToken);
        }

       
    }
}
