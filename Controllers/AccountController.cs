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
using AutoMapper;
using dotnetcore_aurelia_demo.Services;

namespace dotnetcore_aurelia_demo.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserServiceInterface _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly MainDbContext _db;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public AccountController(
            UserServiceInterface userService,
            SignInManager<ApplicationUser> signInManager,
            MainDbContext db, ILogger<AccountController> logger,
            IMapper mapper
          )
        {
            _userService = userService;
            _userManager = userService.GetUserManager();
            _signInManager = signInManager;
            _db = db;
            _logger = logger;
            _mapper = mapper;

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
            _logger.LogInformation(1, string.Format("model email: {0}", model.Email));
            if (ModelState.IsValid)
            {

                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var identity = (ClaimsIdentity)User.Identity;

                    _logger.LogInformation(1, "User logged in.");
                    var res = _mapper.Map<ApplicationUser, UserDto>(user);
                    return new ObjectResult(res);
                }
                else
                {
                    _logger.LogInformation(1, "Invalid login attempt.");
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest();
                }
            }

            // If we got this far, something failed, redisplay form
            return BadRequest();
        }

        //crud users
     
    }


}