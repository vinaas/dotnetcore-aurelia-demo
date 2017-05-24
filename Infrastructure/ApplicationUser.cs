using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace dotnetcore_aurelia_demo.Infrastructure
{
    public class ApplicationUser : IdentityUser
    {
        
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public byte Level { get; set; }

        public DateTime JoinDate { get; set; }
    }
}