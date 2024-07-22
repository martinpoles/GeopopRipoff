using GeopopRipoff.Models.Shared;
using GeopopRipoff.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace GeopopRipoff.ViewComponents
{
    public class SharedComponent : ViewComponent
    {

        private readonly ArticlesRepository _articlesRepository;
        private readonly ArgomentiRepository _argomentiRepository;

        public SharedComponent(ArticlesRepository articlesRepository, ArgomentiRepository argomentiRepository)
        {
            _articlesRepository = articlesRepository;
            _argomentiRepository = argomentiRepository;
        }

        [OutputCache(NoStore = true, Duration = 0)]
        public IViewComponentResult Invoke()
        {

            CommonStructure commonStructure = new CommonStructure();

            commonStructure.Argomenti = _argomentiRepository.GetAllActiveDocument().ToList();

            return View("_CommonStructure", commonStructure);
        }
    }
}
