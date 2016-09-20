using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using TourCity.Web.Infrastructure;

namespace TourCity.Web.Models.Accounts
{
    public class ApplicationUser : IUser<string>
    {
        public string Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        private string passwordHash;
        public string PasswordHash { get { return passwordHash ?? Password; }
            set { passwordHash = value;  }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(CustomUserManager userManager)
        {
           
            ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim("test","test"));
            
            return Task.FromResult(identity);
        }
    }
}