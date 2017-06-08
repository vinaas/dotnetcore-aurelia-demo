using System.ComponentModel.DataAnnotations;

namespace dotnetcore_aurelia_demo.Models.AccountViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }

       
             public string Password { get; set; }

       
        public bool RememberMe { get; set; }=false;
    }
}