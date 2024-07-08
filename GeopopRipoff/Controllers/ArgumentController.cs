using GeopopRipoff.Models;
using GeopopRipoff.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;


namespace GeopopRipoff.Controllers
{
    public class ArgumentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ArticlesRepository _articlesRepository;
        public ArgumentController(ILogger<HomeController> logger, ArticlesRepository articlesRepository)
        {
            _logger = logger;
            _articlesRepository = articlesRepository;
        }
        public IActionResult Index(string itemId)
        {
            WrapperArgumentsPageModel wrapperArgumentsPageModel = new WrapperArgumentsPageModel();
            wrapperArgumentsPageModel.ArgumentsPageModel = new List<ArgumentsPageModel>();

            var argument = _articlesRepository.GetAllCustomers(itemId);

            foreach (var item in argument)
            {
                ArgumentsPageModel argumentsPageModel = new ArgumentsPageModel();
                string imgPath = @$"{item.id_articolo}/{item.id_articolo}.jpg";
                argumentsPageModel.ImgPath = imgPath;
                argumentsPageModel.Title = item.id_articolo.ToString(); ;
                wrapperArgumentsPageModel.ArgumentsPageModel.Add(argumentsPageModel);
                wrapperArgumentsPageModel.Descrizione = item.ds_argomento;
            }

            wrapperArgumentsPageModel.PathHeader = $"/Argument/Header/{itemId}.jpg";

            return View(wrapperArgumentsPageModel);
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
        public IActionResult PullDataFor9More()
        {
            var argument = _articlesRepository.GetAllCustomers("Onlus");

            List<ArgumentsPageModel> values = new List<ArgumentsPageModel>();

            foreach (var item in argument)
            {
                var titolo = item.id_articolo;
                var path = @$"{item.id_articolo}/{item.id_articolo}.jpg";

                ArgumentsPageModel argumentsPageModel = new ArgumentsPageModel();
                string imgPath = @$"/Argument/Onlus/{item.id_articolo}/{item.id_articolo}.jpg";
                argumentsPageModel.ImgPath = imgPath;
                argumentsPageModel.Title = item.id_articolo.ToString(); ;
                values.Add(argumentsPageModel);

            }

            // Converti l'oggetto in una stringa JSON e restituiscilo al client
            return Content(JsonConvert.SerializeObject(values), "application/json");
        }


    }
}
