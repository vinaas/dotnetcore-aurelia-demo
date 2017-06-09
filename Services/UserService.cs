using System;
using dotnetcore_aurelia_demo.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace dotnetcore_aurelia_demo.Services
{
    public class UserService : UserServiceInterface
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public UserManager<ApplicationUser> GetUserManager()
        {
            return this._userManager;
        }
        public RoleManager<IdentityRole> GetRoleManager()
        {
            return _roleManager;
        }
    }
}