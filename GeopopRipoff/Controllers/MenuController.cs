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

namespace GeopopRipoff.Controllers
{
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;

        public MenuController(ILogger<MenuController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //if (TempData["name"] != null)
            //{
            //    return View(TempData["name"]);
            //}
            //else
            //{
            //    return View(new UserProfile());
            //}
            return View();
        }
    }
}
