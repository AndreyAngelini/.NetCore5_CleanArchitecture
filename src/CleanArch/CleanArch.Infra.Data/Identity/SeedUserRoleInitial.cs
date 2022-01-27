using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;

namespace CleanArch.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager,
                                   RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (_userManager.FindByEmailAsync("administrator@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "administrator@localhost";
                user.Email = "administrator@localhost";
                user.NormalizedUserName = "administrator@localhost";
                user.NormalizedEmail = "administrator@localhost";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Newadmin@2021").Result;
                if(result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("user@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "user@localhost";
                user.Email = "user@localhost";
                user.NormalizedUserName = "user@localhost";
                user.NormalizedEmail = "user@localhost";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Newuser@2021").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
        }

        public void SeedUsers()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "User";


                IdentityResult result = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                role.NormalizedName = "Administrator";


                IdentityResult result = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
