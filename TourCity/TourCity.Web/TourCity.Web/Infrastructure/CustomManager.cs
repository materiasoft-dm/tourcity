using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using TourCity.Web.Models.Accounts;

namespace TourCity.Web.Infrastructure
{
    public class CustomUserManager : UserManager<ApplicationUser>
    {
        public CustomUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static CustomUserManager Create()
        {
            var manager = new CustomUserManager(new CustomUserStore());
            return manager;
        }

        public override Task<ApplicationUser> FindAsync(string userName, string password)
        {
            var user = this.FindByNameAsync(userName);
            if (!user.Result.Password.Equals(password)) return null;

           

            return Task.FromResult(user.Result);
        }
    }
}