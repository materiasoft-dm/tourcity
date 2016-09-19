using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.Owin;
using TourCity.Web.Infrastructure;

namespace TourCity.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
         
            app.CreatePerOwinContext<CustomUserManager>(CustomUserManager.Create);
            app.CreatePerOwinContext<CustomSignInManager>(CustomSignInManager.Create);


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });
        }
    }
}