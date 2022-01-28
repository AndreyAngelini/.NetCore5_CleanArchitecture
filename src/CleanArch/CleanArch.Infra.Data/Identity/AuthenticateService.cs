using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        public AuthenticateService(UserManager<ApplicationUser> userManager,
                                   SignInManager<ApplicationUser> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signinManager.PasswordSignInAsync(email, password,false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signinManager.SignOutAsync();
        }

        public async Task<bool> RegusterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
                NormalizedUserName = email,
                NormalizedEmail = email,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
                await _signinManager.SignInAsync(applicationUser, isPersistent: false);

            return result.Succeeded;
        }
    }
}
