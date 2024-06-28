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
using System.Net.Http.Headers;
using Newtonsoft.Json;

//https://www.youtube.com/watch?v=I2PChWTwmM8\\


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

            return View();
        }
    }
}
