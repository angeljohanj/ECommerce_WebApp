using AdminUI.Data;
using AdminUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminUI.Controllers
{
    public class HomeController : Controller
    {
        public UsersData usersData = new UsersData();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
            
        }

        [HttpGet]

        public async Task<JsonResult> ListUsers()
        {
            var users =await usersData.ListUsers();

            return Json(new {data=users});
        }

        public IActionResult RegisterNewUser()
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
