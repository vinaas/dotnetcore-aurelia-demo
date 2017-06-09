using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnetcore_aurelia_demo.Infrastructure;
using dotnetcore_aurelia_demo.Models.AccountViewModels;
using dotnetcore_aurelia_demo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetcore_aurelia_demo.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserServiceInterface _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public UsersController(UserServiceInterface userService, IMapper mapper)
        {
            _userService = userService;
            _userManager = _userService.GetUserManager();
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var result = users.Select(x => _mapper.Map<ApplicationUser, UserDto>(x));
            // var res = _mapper.Map<ApplicationUser, UserDto>(user);
            return new ObjectResult(result);

        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return new ObjectResult(_mapper.Map<ApplicationUser, UserDto>(user));
        }
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> PutUser(string id, UserDto bindingUser)
        {
            var user = await _userManager.FindByEmailAsync(bindingUser.Id);
            user.Email = bindingUser.Email;
            user.FirstName = bindingUser.FirstName;
            user.LastName = bindingUser.LastName;
            user.Address = bindingUser.Address;
            user.PhoneNumber = bindingUser.PhoneNumber;
            await _userManager.UpdateAsync(user);
            return NoContent();
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            await _userManager.DeleteAsync(user);
            return new ObjectResult(_mapper.Map<ApplicationUser, UserDto>(user));
        }

    }
}