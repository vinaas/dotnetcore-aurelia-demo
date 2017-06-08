using dotnetcore_aurelia_demo.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace dotnetcore_aurelia_demo.Services
{
    public interface UserServiceInterface
    {
        UserManager<ApplicationUser> GetUserManager();
    }
}