using GeopopRipoff.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using Facebook;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using Newtonsoft.Json.Linq;

namespace GeopopRipoff.Controllers
{
    public class LogSignInOutController : Controller
    {
        private readonly ILogger<LogSignInOutController> _logger;

        public LogSignInOutController(ILogger<LogSignInOutController> logger)
        {
            _logger = logger;
        }

        public ActionResult SignIn()
        {
            var fb = new FacebookClient();
            var loginUri = fb.GetLoginUrl(new
            {
                client_id = "1015689366876643",
                redirect_uri = "https://localhost:44335/LogSignInOut/FacebookRedirect",
                scope = "public_profile,email",
                fields = "email"
            });

            ViewBag.Url = loginUri;

            return View();
        }


        public ActionResult FacebookRedirect(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Get("/oauth/access_token", new
            {
                client_id = "1015689366876643",
                client_secret = "4f646c3d845661f71d591aae07154c85",
                redirect_uri = "https://localhost:44335/LogSignInOut/FacebookRedirect",
                code = code
            });

            fb.AccessToken = result.access_token;

            dynamic me = fb.Get("/me?field=name,email");
            string name = me.name;
            string email = me.email;

            //retrive(me.id, fb.AccessToken);

            UserProfile userProfile = new UserProfile();

            userProfile.NomeCognome = me.name;

            return View("../Home/Menu", userProfile);
        }
    }
}
