using App.Domain.Core.DtoModels.AccountDtoModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contracts.ApplicationService
{
    public interface IAccountApplicationService
    {
        Task<SignInResult> Login(LoginUserDto loginUser);
        Task<IdentityResult> Register(RegisterUserDto appUser);
    }
}
