using AutoMapper;
using dotnetcore_aurelia_demo.Infrastructure;
using dotnetcore_aurelia_demo.Models.AccountViewModels;

namespace dotnetcore_aurelia_demo
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ApplicationUser, LoginResultModel>();
        }
    }
}