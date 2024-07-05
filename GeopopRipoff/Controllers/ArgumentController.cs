using GeopopRipoff.Models;
using GeopopRipoff.Repository;
using Microsoft.AspNetCore.Mvc;

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
    }
}
