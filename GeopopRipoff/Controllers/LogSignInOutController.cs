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

namespace GeopopRipoff.Controllers
{
    public class LogSignInOutController : Controller
    {
        private readonly ILogger<LogSignInOutController> _logger;
        private readonly LogSignInOutRepository _logSignInOutRepository;

        public LogSignInOutController(ILogger<LogSignInOutController> logger, LogSignInOutRepository logSignInOutRepository)
        {
            _logger = logger;
            _logSignInOutRepository = logSignInOutRepository;
        }

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SaveUserData([FromBody] UserProfile user)
        {
            if (ModelState.IsValid)
            {
                int oid = _logSignInOutRepository.InsertUtente(user.Name, "", "", user.Email);
             
                return Json(new { success = true, message = "Dati salvati con successo.", oid = oid});
                }
            else
            {
                // Se ci sono errori di validazione, restituisci un oggetto JSON con gli errori
                return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
            }
        }
    }
}
