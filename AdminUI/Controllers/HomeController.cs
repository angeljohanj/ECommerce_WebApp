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

        public async Task<IActionResult> Users()
        {
            var users = await usersData.ListUsers();
            if (ModelState.IsValid)
            {
                return View(users);
            }

            return RedirectToAction("Error");
            
        }

               
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
