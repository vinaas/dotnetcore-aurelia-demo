using dotnetcore_aurelia_demo.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace dotnetcore_aurelia_demo.Services
{
    public interface UserServiceInterface
    {
        UserManager<ApplicationUser> GetUserManager();
        RoleManager<IdentityRole> GetRoleManager();
    }
}