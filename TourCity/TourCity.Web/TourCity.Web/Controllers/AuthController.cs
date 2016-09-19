using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using TourCity.Web.Infrastructure;
using TourCity.Web.Models.Accounts;

namespace TourCity.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private CustomSignInManager _signInManager;
        public CustomSignInManager CustomSignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<CustomSignInManager>();
            }
            private set { _signInManager = value; }
        }

        // GET: Auth
        public ActionResult Login(string returnUrl)
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(ApplicationUser user)
        {
            CustomSignInManager.SignIn(user, isPersistent:true, rememberBrowser:false);
            return View();
        }

        public ActionResult LogOut()
        {
            CustomSignInManager.AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }


    }
}