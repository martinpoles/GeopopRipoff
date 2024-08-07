using GeopopRipoff.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using Facebook;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using GeopopRipoff.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using GeopopRipoff.Models.Menu;

namespace GeopopRipoff.Controllers
{
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;

        private readonly ArticlesRepository _articlesRepository;
        private readonly ArgomentiRepository _argomentiRepository;
        private readonly LogSignInOutRepository _logSignInOutRepository;
        public MenuController(ILogger<MenuController> logger, ArticlesRepository articlesRepository, ArgomentiRepository argomentiRepository
            , LogSignInOutRepository logSignInOutRepository)
        {
            _logger = logger;
            _articlesRepository = articlesRepository;
            _argomentiRepository = argomentiRepository;
            _logSignInOutRepository = logSignInOutRepository;
        }
        public IActionResult Index(string oid)
        {
            MenuIndex menuIndex = new MenuIndex();

            menuIndex.Argomenti = _argomentiRepository.GetAllActiveDocument().ToList();

            if (!string.IsNullOrEmpty(oid))
            {
                menuIndex.Utente = _logSignInOutRepository.GetUtenteByOid(oid);
            }

            return View(menuIndex);
        }
    }
}
