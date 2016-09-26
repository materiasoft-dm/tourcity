using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;
using System.Configuration;
using System.Net;
using System.IO;

namespace TourCity.Web.Areas.Api.Controllers
{
    public class FacebookManagerController : Controller
    {
        // GET: Api/FacebookManager
        [AllowAnonymous]
        public ActionResult Register()
        {
            CheckAuthorization();
            return View();
        }

        public void CheckAuthorization()
        {
            string app_id = ConfigurationManager.AppSettings["facebookAppId"];
            string app_secret = ConfigurationManager.AppSettings["facebookAppSecret"];
            //https://developers.facebook.com/docs/facebook-login/permissions

            string scope = "public_profile,user_friends,email,publish_pages";

            if(Request["code"]== null)
            {
                Response.Redirect(string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                    app_id, Request.Url.AbsoluteUri, scope));
            }
            else
            {
                Dictionary<string, string> tokens = new Dictionary<string, string>();

                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                    app_id,Request.Url.AbsoluteUri, scope, Request["code"], app_secret);

                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string vals = reader.ReadToEnd();
                        foreach(string token in vals.Split('&'))
                        {
                            tokens.Add(token.Split('=')[0], token.Split('=')[1]);
                        }
                    }
                }

                string access_token = tokens["access_token"];

                var client = new FacebookClient(access_token);

                
            }
        }
    }
}