using App.Domain.Core.DtoModels.AccountDtoModels;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Contracts.Repository
{
    public interface IAccountApplicationRepository
    {
        Task<SignInResult> Login(LoginUserDto loginUser);
        Task<IdentityResult> Register(RegisterUserDto appUser);
    }
}