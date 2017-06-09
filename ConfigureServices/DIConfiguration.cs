using dotnetcore_aurelia_demo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace dotnetcore_aurelia_demo.ConfigureServices
{
    public static class DIConfiguration
    {
        public static IServiceCollection AddCustomDI(this IServiceCollection services)
        {
            services.AddTransient<UserServiceInterface, UserService>();

            return services;
        }

    }
}