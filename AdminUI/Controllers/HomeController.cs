﻿using AdminUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminUI.Controllers
{
    public class HomeController : Controller
    {      

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
