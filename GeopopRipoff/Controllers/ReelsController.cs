using GeopopRipoff.Models.Home;
using GeopopRipoff.Models.Reels;
using GeopopRipoff.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GeopopRipoff.Controllers
{
    public class ReelsController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ArticlesRepository _articlesRepository;
        private readonly ArgomentiRepository _argomentiRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ReelsController(ILogger<HomeController> logger, IConfiguration configuration, ArticlesRepository articlesRepository, ArgomentiRepository argomentiRepository, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _configuration = configuration;
            _articlesRepository = articlesRepository;
            _argomentiRepository = argomentiRepository;
            _hostingEnvironment = hostingEnvironment;
        }



        public IActionResult Index(string id_reels)
        {
            ReelsIndex reelsIndex = new ReelsIndex();

        
            var reels = _articlesRepository.GetLast5Reels();


            foreach (var reel in reels)
            {
                Content cont = new Content();
                cont.Id_Contenuto = reel.Id_Contenuto;

                cont.Path = @$"/DataMultimedia/Contenuti/{reel.Id_Contenuto}/{reel.Id_Contenuto}.mp4";
                reelsIndex.List_Reels.Add(cont);
            }


            if (!id_reels.IsNullOrEmpty())
            {
                //il reels premuto se abbiamo
                reelsIndex.Id_Reels = default;

            }

            return View(reelsIndex);
        }
    }
}
