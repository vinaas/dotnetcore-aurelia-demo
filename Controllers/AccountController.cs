using System.Threading.Tasks;
using dotnetcore_aurelia_demo.Infrastructure;
using dotnetcore_aurelia_demo.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.Extensions.Logging;

namespace dotnetcore_aurelia_demo.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly MainDbContext _db;
        private readonly ILogger _logger;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            MainDbContext db, ILogger<AccountController> logger
          )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _logger = logger;

        }
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                // Send an email with this link
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                //    "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                await _signInManager.SignInAsync(user, isPersistent: false);

                return Ok();
            }
            else
                return BadRequest();
        }


        [HttpGet]
        [Authorize]
        [Route("GetUsers")]
        public async Task<List<ApplicationUser>> GetUsers()
        {
            return await _userManager.Users.ToListAsync<ApplicationUser>();
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("UserLogin")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            _logger.LogInformation(string.Format("model email: {0}"), model.Email);
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return new ObjectResult(result);
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest();
                }
            }
            _logger.LogInformation(1, "Model InValid");

            // If we got this far, something failed, redisplay form
            return BadRequest();
        }
        [HttpGet]

        [Route("test")]
        public async Task<string> getValue()
        {
            _logger.LogDebug("what");
            await Task.Delay(100);
            return "some";
        }
        [HttpGet]
        [Route("getIdentity")]
        public async Task<dynamic> GetIdentity(string email, string password)
        {
            _logger.LogInformation(string.Format("email : {0} password: {1}", email, password));
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            _logger.LogDebug(string.Format("result: {0}", result));
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);
                _logger.LogDebug(string.Format("user {0}", user.Email));
                var claims = await _userManager.GetClaimsAsync(user);

                return claims;
            }

            // Credentials are invalid, or account doesn't exist
            return null;
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }



    }


}