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

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public JsonResult SaveUserData([FromBody]UserProfile user)
        {
            {
                if (ModelState.IsValid)
                {
                    // Qui puoi gestire i dati dell'utente come preferisci
                    // Ad esempio, salvarli in una sessione, un file, ecc.
                    // In questo esempio, salviamo i dati in una sessione
                    var g = user;

                    return Json(new { success = true, message = "User data saved successfully" });
                }
                return Json(new { success = false, message = "Invalid data" });
            }
        }

    }
}
