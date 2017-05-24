using System;
using dotnetcore_aurelia_demo.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace dotnetcore_aurelia_demo.ConfigureServices
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddCustomizedIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<MainDbContext, IdentityRole>()
                .AddEntityFrameworkStores<MainDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
                {
                    // Password settings
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = false;

                    // Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    options.Lockout.MaxFailedAccessAttempts = 10;

                    // Cookie settings
                    options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
                    options.Cookies.ApplicationCookie.LoginPath = "/Account/LogIn";
                    options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOut";

                    // User settings
                    options.User.RequireUniqueEmail = true;
                });
            return services;
        }
    }
}