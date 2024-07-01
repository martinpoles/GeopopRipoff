using GeopopRipoff.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using Facebook;

namespace GeopopRipoff.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public ActionResult Argument(string itemId)
        {
            //premo il bottone 
            //entro qua e in base al bottone valorizzo il model 
            //utilizzo il model per generare la view successiva
            return View();
        }
        [HttpPost]
        public ActionResult Notifiche()
        {
            //premo il bottone 
            //entro qua e in base al bottone valorizzo il model 
            //utilizzo il model per generare la view successiva
            return View();
        }
        [HttpPost]
        public ActionResult Menu(UserProfile userProfile = null)
        {
            if (userProfile == null)
            {
                return View();
            }
            else
            {
                return View(userProfile);
            }

        }
        public ActionResult PrivacyPolicy()
        {
            return View();
        }
        public ActionResult CookiePolicy()
        {
            return View();
        }
        public ActionResult Redazione()
        {
            return View();
        }
        public ActionResult ModificaConsenso()
        {
            return View();
        }
        public ActionResult Impostazioni()
        {
            return View();
        }

    }
}
