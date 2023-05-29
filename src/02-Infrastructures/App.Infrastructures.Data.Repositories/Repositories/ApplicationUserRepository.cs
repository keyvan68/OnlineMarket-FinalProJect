using App.Domain.Core.DtoModels;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Data.Repositories.Repositories
{
    public class ApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(ApplicationUserDto userDto, string role)
        {
            var user = new ApplicationUser
            {
                Email = userDto.Email,
                UserName = userDto.UserName
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            return result;
        }

        public async Task<SignInResult> Login(ApplicationUserDto userDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userDto.UserName, userDto.Password, isPersistent: false, lockoutOnFailure: false);
            return result;
        }
        //public async Task<bool> Login1(string username, string password)
        //{
        //    // Implementation of login logic using the provided username and password
        //    // Check if the user credentials are valid and set the appropriate roles

        //    // Example implementation:
        //    // Assuming you have a user service or repository to retrieve the user information
        //    var user = await _userService.GetUserByUsername(username);
        //    if (user != null && user.Password == password)
        //    {
        //        Roles = new List<string>();

        //        // Set the roles based on user's role property
        //        if (user.Role == "seller")
        //        {
        //            Roles.Add("seller");
        //        }
        //        else if (user.Role == "buyer")
        //        {
        //            Roles.Add("buyer");
        //        }
        //        else if (user.Role == "admin")
        //        {
        //            Roles.Add("admin");
        //        }

        //        return true;
        //    }

        //    return false;
        //}

        //public async Task<bool> Register1()
        //{
        //    // Implementation of registration logic using the provided user information

        //    // Example implementation:
        //    // Assuming you have a user service or repository to handle user registration
        //    var user = new ApplicationUser
        //    {
        //        UserName = UserName,
        //        Email = Email,
        //        // Set other properties as needed
        //    };

        //    // Register the user using your user service/repository
        //    var result = await _userService.RegisterUser(user, Password);

        //    // Check the registration result and return true or false based on success
        //    return result;
        //}
    }
}
