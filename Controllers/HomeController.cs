using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace my_app.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // var userService = new UserServices("");
            // if (userService.GetListUser()) return Ok();
            
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
