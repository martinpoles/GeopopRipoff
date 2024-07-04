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
        public IActionResult Index()
        {
            var argument = _articlesRepository.GetAllCustomersAsync(default);

            return View();
        }
        public IActionResult Article(string itemId)
        {
            return View();
        }
    }
}
