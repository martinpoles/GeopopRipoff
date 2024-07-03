using GeopopRipoff.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using Facebook;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using System.Xml.Serialization;
using System.Xml;
using GeopopRipoff.Utility;

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
            //itemId rappresenta l'oid del elemento sul db 
            //Tramite quel valore recuperiamo tutti gli articoli pertinenti



            Argument argument = new Argument();


            return View(argument);
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


        public ActionResult Policy(string itemId)
        {

            string xmlFilePath = "C:\\Users\\ssoko\\Desktop\\TEMP\\TestXml.xml";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            GeopopRipoff.Utility.Document document = new GeopopRipoff.Utility.Document();


            // Leggi il titolo e l'intestazione
            document.Title = xmlDoc.SelectSingleNode("/body/title")?.InnerText;
            document.Header = xmlDoc.SelectSingleNode("/body/header")?.InnerText;
            document.Sections = new List<Section>();


            // Leggi le sezioni
            XmlNodeList sectionNodes = xmlDoc.SelectNodes("/body/sections/section");
            if (sectionNodes != null)
            {
                foreach (XmlNode sectionNode in sectionNodes)
                {
                    document.Sections.Add(new Section(sectionNode.SelectSingleNode("subtitle")?.InnerText, sectionNode.SelectSingleNode("content")?.InnerText));
                }
            }

            switch (itemId)
            {
                case "1":
                    break;
                default:
                    break;
            }
            return View(document);
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
