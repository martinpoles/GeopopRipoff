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
using Microsoft.Extensions.Hosting.Internal;


namespace GeopopRipoff.Controllers
{
    public class ArgumentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ArticlesRepository _articlesRepository;
        private readonly ArgomentiRepository _argomentiRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ArgumentController(ILogger<HomeController> logger, IConfiguration configuration, ArticlesRepository articlesRepository, ArgomentiRepository argomentiRepository, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _configuration = configuration;
            _articlesRepository = articlesRepository;
            _argomentiRepository = argomentiRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index(string id_argomento)
        {
            ArgumentIndex argumentIndex = new ArgumentIndex();

            int counter = 0;

            var ListArticle = _articlesRepository.GetArticleByArgomento(id_argomento);

            foreach (var item in ListArticle)
            {
                if (counter == 9)
                    break;
                ContenutoArgumentArticle contenutoArgumentArticle = new ContenutoArgumentArticle();

                contenutoArgumentArticle.ImgPath = @$"/DataMultimedia/Contenuti/{item.Id_Contenuto}/{item.Id_Contenuto}_1.jpg";

                contenutoArgumentArticle.Title = item.Id_Contenuto;
                argumentIndex.Contenuti.Add(contenutoArgumentArticle);
                counter++;
            }

            //argumentIndex.Argomenti = _argomentiRepository.GetAllActiveDocument().ToList(); ;

            argumentIndex.PathHeader = $"/DataMultimedia/Header/{id_argomento}.jpg";

            argumentIndex.Descrizione = _argomentiRepository.GetArgumentDescriptionByIdArgument(id_argomento).FirstOrDefault();

            argumentIndex.Id_Argomento = id_argomento;

            return View(argumentIndex);
        }
        public IActionResult Article(string id_articolo, string id_argomento)
        {
            ArticleXml article = new ArticleXml();

            //recupero da db 
            var argument = _articlesRepository.GetArticleByIdArticle(id_articolo);

            article.Autore.Id_Autore = argument.id_autore;

            article.DtPubblicazione = argument.dt_pubblicazione;

            var pathRoot = @$"/DataMultimedia/Contenuti/{id_articolo}";

            var pathXml = @$"{pathRoot}/{id_articolo}.xml";

            var pathRootAbsolute = _hostingEnvironment.ContentRootPath + "/wwwroot" + pathRoot;

            FileInfo fileInfo12 = new FileInfo(pathRootAbsolute);

            string[] fileNames = Directory.GetFiles(pathRootAbsolute);
            Regex regex = new Regex(@".*_\d+\.jpg$");
            var validFileNames = fileNames.Where(fileName => regex.IsMatch(Path.GetFileName(fileName)));

            List<string> fileList = new List<string>();


            foreach (var fileName in validFileNames)
            {
                string searchString = @"/DataMultimedia/";
                int index = fileName.IndexOf(searchString);
                string result = "";

                if (index >= 0)
                {
                    // Extract the substring starting from the search string
                    result = fileName.Substring(index);
                }

                fileList.Add(result.ToString());
            }


            FileInfo fileInfo = new FileInfo(_hostingEnvironment.ContentRootPath + "/wwwroot" + pathXml);

            if (fileInfo.Exists)
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load((_hostingEnvironment.ContentRootPath + "/wwwroot" + pathXml));

                // Leggi il titolo e l'intestazione
                article.Title = xmlDoc.SelectSingleNode("/article/title")?.InnerText;
                article.Header = xmlDoc.SelectSingleNode("/article/header")?.InnerText;
                article.Chapters = new List<Chapters>();


                //article.Argomenti = _argomentiRepository.GetAllActiveDocument().ToList();

                // Leggi le sezioni
                XmlNodeList sectionNodes = xmlDoc.SelectNodes("/article/chapters/chapter");
                int i = 0;
                if (sectionNodes != null)
                {
                    foreach (XmlNode sectionNode in sectionNodes)
                    {
                        if (i < fileList.Count)
                        {
                            article.Chapters.Add(new Chapters(sectionNode.SelectSingleNode("subtitle")?.InnerText, sectionNode.SelectSingleNode("content")?.InnerText, fileList[i]));
                        }
                        else
                        {
                            article.Chapters.Add(new Chapters(sectionNode.SelectSingleNode("subtitle")?.InnerText, sectionNode.SelectSingleNode("content")?.InnerText));
                        }
                        i++;
                    }
                }
            }
            return View(article);
        }

        [HttpPost]
        public IActionResult PullDataFor9More([FromBody] TrashBag trashBag)
        {
            ArgumentIndex argumentIndex = new ArgumentIndex();

            int index = 0;

            var ListArticle = _articlesRepository.GetArticleByArgomento(trashBag.id_argomento).ToList();


            for (int i = (trashBag.counter * 9); i < ListArticle.Count(); i++)
            {
                ContenutoArgumentArticle contenutoArgumentArticle = new ContenutoArgumentArticle();

                contenutoArgumentArticle.ImgPath = @$"/DataMultimedia/Contenuti/{ListArticle[i].Id_Contenuto}/{ListArticle[i].Id_Contenuto}_1.jpg";

                contenutoArgumentArticle.Title = ListArticle[i].Id_Contenuto;
                argumentIndex.Contenuti.Add(contenutoArgumentArticle);
                if (argumentIndex.Contenuti.Count >= 9)
                    break;
            }

            // Converti l'oggetto in una stringa JSON e restituiscilo al client
            return Content(JsonConvert.SerializeObject(argumentIndex), "application/json");
        }
    }
}
