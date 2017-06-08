using System;
using dotnetcore_aurelia_demo.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace dotnetcore_aurelia_demo.Services
{
    public class UserService : UserServiceInterface
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public UserManager<ApplicationUser> GetUserManager()
        {
            return this._userManager;
        }
    }
}