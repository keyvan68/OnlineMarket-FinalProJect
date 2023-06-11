using App.Domain.Core.Contracts.ApplicationService;
using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.AccountDtoModels;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.ApplicationServices
{
    public class AccountApplicationService : IAccountApplicationService
    {
        private readonly IAccountApplicationRepository _accountApplicationRepository;
        


        public AccountApplicationService(IAccountApplicationRepository accountApplicationRepository)
        {
            _accountApplicationRepository = accountApplicationRepository;
            
            
        }

        public async Task<SignInResult> Login(LoginUserDto loginUser)
        {
          var result= await _accountApplicationRepository.Login(loginUser);
            return result;
        }

        public async Task<IdentityResult> Register(RegisterUserDto appUser)
        {
            var result = await _accountApplicationRepository.Register(appUser);
            return result;
        }
    }
}
