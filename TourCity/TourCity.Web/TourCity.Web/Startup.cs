using System;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using TourCity.Web.Infrastructure;

namespace TourCity.Web
{
    public class Startup
    {
        public static string PublicClientId { get; private set; }
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
         
            app.CreatePerOwinContext<CustomUserManager>(CustomUserManager.Create);
            app.CreatePerOwinContext<CustomSignInManager>(CustomSignInManager.Create);


            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = "ApplicationCookie",
            //    LoginPath = new PathString("/auth/login")
            //});

            PublicClientId = "self";

            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/Account/Login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };

            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}