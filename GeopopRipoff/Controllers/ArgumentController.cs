using Microsoft.AspNetCore.Mvc;

namespace GeopopRipoff.Controllers
{
    public class ArgumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Article(string itemId)
        {
            return View();
        }
    }
}
