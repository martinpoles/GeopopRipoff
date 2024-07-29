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
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ArticlesRepository _articlesRepository;
        private readonly ArgomentiRepository _argomentiRepository;
        private readonly ReelsRepository _reelsRepository;

        public ReelsController(ILogger<HomeController> logger, IConfiguration configuration, ArticlesRepository articlesRepository, ArgomentiRepository argomentiRepository, IWebHostEnvironment hostingEnvironment, ReelsRepository reelsRepository)
        {
            _logger = logger;
            _configuration = configuration;
            _articlesRepository = articlesRepository;
            _argomentiRepository = argomentiRepository;
            _hostingEnvironment = hostingEnvironment;
            _reelsRepository = reelsRepository;
        }

        public IActionResult Index(string id_reels)
        {
            return View(ModelForIndex(id_reels));
        }


        public IActionResult Video(string id_reels)
        {
            return View();
        }


        public IActionResult ShareBtn(string id_reels)
        {
            return View("Index");
        }

        public IActionResult LikeBtn(string id_reels)
        {
            //controllo se sono loggato 

            //se non sono loggato, mando a schermata log 

            //cerco se ho già dato questo like
            var likeExists = _reelsRepository.CheckLikeOnReel("", id_reels);


            if (likeExists != null)
            {
                //se si cambio il flag del record 
                _reelsRepository.UpdateLikeStatus("", id_reels);
                
            }
            else
            {
                //se no eseguo insert   
                var insertRes = _reelsRepository.InsertLike("", id_reels);

            }

            //ricarico il model e vado alla view
            ReelsIndex reelsIndex = ModelForIndex();


            return View("Index", ModelForIndex(id_reels));

        }
        
        public IActionResult CommentBtn(string id_reels)
        {
            return View("Index");
        }


        private ReelsIndex ModelForIndex(string id_reels = null)
        {

            // Creazione dell'oggetto di view model
            ReelsIndex reelsIndex = new ReelsIndex();

            // Recupero della lista di reels e dati aggiuntivi
            var reels = _articlesRepository.GetAllReelsAndExtraData();

            // Aggiornamento del percorso per ogni reel
            foreach (var reel in reels)
            {
                reel.Path = @$"/DataMultimedia/Contenuti/{reel.Id_Contenuto}/{reel.Id_Contenuto}.mp4";
                reelsIndex.List_Reels.Add(reel);
            }

            // Ordinamento della lista se id_reels è valorizzato
            if (!string.IsNullOrEmpty(id_reels))
            {
                // Trova il reel con l'id specificato
                var specifiedReel = reelsIndex.List_Reels.FirstOrDefault(reel => reel.Id_Contenuto == id_reels);

                if (specifiedReel != null)
                {
                    // Rimuovi il reel specificato dalla lista
                    reelsIndex.List_Reels.Remove(specifiedReel);

                    // Inserisci il reel specificato come primo nella lista
                    reelsIndex.List_Reels.Insert(0, specifiedReel);
                }
            }
            return reelsIndex;
        }
    }
}