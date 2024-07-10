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
using GeopopRipoff.Repository;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Identity.Client.Extensions.Msal;
using GeopopRipoff.Models.Home;

namespace GeopopRipoff.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ArticlesRepository _articlesRepository;
        private readonly ArgomentiRepository _argomentiRepository;

        public HomeController(ILogger<HomeController> logger, ArticlesRepository articlesRepository, ArgomentiRepository argomentiRepository)
        {
            _logger = logger;
            _articlesRepository = articlesRepository;
            _argomentiRepository = argomentiRepository;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            return View(GetIndexData());
        }

        public IActionResult Privacy()
        {
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

        private HomeIndex GetIndexData()
        {
            HomeIndex index = new HomeIndex();

            //argomenti
            index.Argomenti = _argomentiRepository.GetAllActiveDocument().ToList();

            //storie
            var contenuto = _articlesRepository.GetLast2WeekStories();


            for (int i = 0; i < contenuto.Count; i++)
            {
                Content contenuto1 = new Content();

                contenuto1.Id_Contenuto = contenuto[i].id_contenuto;

                contenuto1.Path = @$"\Argument\{contenuto[i].id_argomento}\{contenuto[i].id_contenuto}\{contenuto[i].id_contenuto}_1.jpg";

                index.Storie.Add(contenuto1);
                if (i <= 5)
                {
                    //show case
                    index.ShowCase.Add(contenuto1);
                }
            }

            //reels
            var reels = _articlesRepository.GetLast5Reels();

            foreach (var reel in reels)
            {
                Content cont = new Content();
                cont.Id_Contenuto = reel.Id_Contenuto;

                cont.Path = @$"\Video\{reel.Id_Contenuto}.mp4";
                index.Reels.Add(cont);
            }
            //Da completare

            return index;
        }

    }
}
