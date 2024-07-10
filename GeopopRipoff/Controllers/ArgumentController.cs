using GeopopRipoff.Models;
using GeopopRipoff.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using GeopopRipoff.Models.Argument;


namespace GeopopRipoff.Controllers
{
    public class ArgumentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ArticlesRepository _articlesRepository;
        private readonly ArgomentiRepository _argomentiRepository;
        public ArgumentController(ILogger<HomeController> logger, ArticlesRepository articlesRepository, ArgomentiRepository argomentiRepository)
        {
            _logger = logger;
            _articlesRepository = articlesRepository;
            _argomentiRepository = argomentiRepository;
        }

        public IActionResult Index(string id_argomento)
        {
            ArgumentIndex argumentIndex = new ArgumentIndex();

            foreach (var item in _articlesRepository.Get9ArticleByArgomento(id_argomento))
            {
                ContenutoArgumentArticle contenutoArgumentArticle = new ContenutoArgumentArticle();
                contenutoArgumentArticle.ImgPath = @$"{item.Id_Contenuto}/{item.Id_Contenuto}.jpg";
                contenutoArgumentArticle.Title = item.Id_Contenuto;
                argumentIndex.Contenuti.Add(contenutoArgumentArticle);
            }

            argumentIndex.PathHeader = $"/Argument/Header/{id_argomento}.jpg";

            argumentIndex.Descrizione = _argomentiRepository.GetArgumentDescriptionByIdArgument(id_argomento).FirstOrDefault();

            argumentIndex.Id_Argomento = id_argomento;

            return View(argumentIndex);
        }
        public IActionResult Article(string id_articolo)
        {
            //recupero da db 
            var argument = _articlesRepository.GetArticleByIdArticle(id_articolo);

            var pathRoot = @$"C:\Users\ssoko\Desktop\Personal\Code\GeopopRipoff\GeopopRipoff\GeopopRipoff\wwwroot\Argument\Onlus\{id_articolo}";

            var pathXml = @$"C:\Users\ssoko\Desktop\Personal\Code\GeopopRipoff\GeopopRipoff\GeopopRipoff\wwwroot\Argument\Onlus\{id_articolo}\{id_articolo}.xml";


            string[] fileNames = Directory.GetFiles(pathRoot);
            Regex regex = new Regex(@".*_\d+\.jpg$");
            var validFileNames = fileNames.Where(fileName => regex.IsMatch(Path.GetFileName(fileName)));

            List<string> fileList = new List<string>();
            foreach (var fileName in validFileNames)
            {
                string searchString = @"\Argument\";
                int index = fileName.IndexOf(searchString);
                string result = "";

                if (index >= 0)
                {
                    // Extract the substring starting from the search string
                    result = fileName.Substring(index);
                }

                fileList.Add(result.ToString());
            }


            ArticleXml article = new ArticleXml();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathXml);

            // Leggi il titolo e l'intestazione
            article.Title = xmlDoc.SelectSingleNode("/article/title")?.InnerText;
            article.Header = xmlDoc.SelectSingleNode("/article/header")?.InnerText;
            article.Chapters = new List<Chapters>();


            // Leggi le sezioni
            XmlNodeList sectionNodes = xmlDoc.SelectNodes("/article/chapters/chapter");
            int i = 0;
            if (sectionNodes != null)
            {
                foreach (XmlNode sectionNode in sectionNodes)
                {
                    if (i < fileList.Count)
                    {
                        article.Chapters.Add(new Chapters(sectionNode.SelectSingleNode("subtitle")?.InnerText, sectionNode.SelectSingleNode("chapter")?.InnerText, fileList[i]));
                    }
                    else
                    {
                        article.Chapters.Add(new Chapters(sectionNode.SelectSingleNode("subtitle")?.InnerText, sectionNode.SelectSingleNode("chapter")?.InnerText));
                    }
                    i++;
                }
            }

            return View(article);
        }

        [HttpPost]
        public IActionResult PullDataFor9More([FromBody] TrashBag trashBag)
        {
            ArgumentIndex argumentIndex = new ArgumentIndex();

            foreach (var item in _articlesRepository.Get9ArticleByArgomento(trashBag.id_argomento))
            {
                ContenutoArgumentArticle contenutoArgumentArticle = new ContenutoArgumentArticle();
                contenutoArgumentArticle.ImgPath = @$"/Argument/{trashBag.id_argomento}/{item.Id_Contenuto}/{item.Id_Contenuto}.jpg";
                contenutoArgumentArticle.Title = item.Id_Contenuto;
                argumentIndex.Contenuti.Add(contenutoArgumentArticle);
            }

            // Converti l'oggetto in una stringa JSON e restituiscilo al client
            return Content(JsonConvert.SerializeObject(argumentIndex), "application/json");
        }
    }
}
