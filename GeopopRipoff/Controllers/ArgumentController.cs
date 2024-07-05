using GeopopRipoff.Models;
using GeopopRipoff.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public IActionResult Article(string itemId)
        {
            return View();
        }


        [HttpPost]
        public IActionResult PullDataFor9More()
        {
            var argument = _articlesRepository.GetAllCustomers("Onlus");

            List<ArgumentsPageModel> values = new List<ArgumentsPageModel>();

            foreach (var item in argument)
            {
                var titolo = item.id_articolo;
                var path  = @$"{item.id_articolo}/{item.id_articolo}.jpg";

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
