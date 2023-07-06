using App.Domain.Core.Contracts.Repository;
using App.Domain.Core.DtoModels.AccountDtoModels;
using App.Domain.Core.Entities;
using App.Infrastructures.Db.SqlServer.Ef.Database;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace App.Infrastructures.Data.Repositories.Repositories
{
    public class AccountApplicationRepository : IAccountApplicationRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        

        public AccountApplicationRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            
        }
        public async Task<IdentityResult> Register(RegisterUserDto appUser)
        {
            //Seller = new Seller()
            //var user = new ApplicationUser { UserName = appUser.Email, Email = appUser.Email, EmailConfirmed = true,Seller = new Seller() {

            //    CreatedAt = DateTime.Now
                
            //}  };
            var user = new ApplicationUser();
            if (appUser.Role == "buyer")
            {
                user = new ApplicationUser
                {
                    UserName = appUser.Email,
                    Email = appUser.Email,
                    EmailConfirmed = true,
                    Buyer = new Buyer()
                    {
                        CreatedAt=DateTime.Now
                    }
                };
            }

            if (appUser.Role == "seller")
            {
                user = new ApplicationUser
                {
                    UserName = appUser.Email,
                    Email = appUser.Email,
                    EmailConfirmed = true,
                    Seller = new Seller()
                    {
                        CreatedAt = DateTime.Now
                    }
                };
            }
            var result = await _userManager.CreateAsync(user, appUser.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "buyer");
                await _signInManager.SignInAsync(user, isPersistent: false);

            }
            return result;
        }
       
        public async Task<SignInResult> Login(LoginUserDto loginUser)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, loginUser.RememberMe, false);
            
            return result;
        }
    }
}
