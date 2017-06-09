using AutoMapper;
using dotnetcore_aurelia_demo.Infrastructure;
using dotnetcore_aurelia_demo.Models.AccountViewModels;

namespace dotnetcore_aurelia_demo.ConfigureServices
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<ApplicationUser, UserDto>();
        }
    }
}