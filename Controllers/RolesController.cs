using System.Threading.Tasks;
using dotnetcore_aurelia_demo.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetcore_aurelia_demo.Controllers
{
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(UserServiceInterface userService)
        {
            _roleManager = userService.GetRoleManager();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return new ObjectResult(roles);

        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetRole(string id)
        {
            return new ObjectResult(await _roleManager.FindByIdAsync(id));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> PostRole(IdentityRole role)
        {
            var result = await _roleManager.CreateAsync(role);
            return new ObjectResult(role);
        }
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> PutRole(string id, IdentityRole role)
        {
            var r = await _roleManager.FindByIdAsync(id);
            if (r == null) return NotFound();
            await _roleManager.UpdateAsync(role);
            return NoContent();
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var r = await _roleManager.FindByIdAsync(id);
            if (r == null) return NotFound();
            await _roleManager.DeleteAsync(r);
            return new ObjectResult(r);
        }
        
    }
}