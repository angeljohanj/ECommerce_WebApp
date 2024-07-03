using Microsoft.AspNetCore.Mvc;

namespace AdminUI.Controllers
{
    public class MaintainerController : Controller
    {
        public IActionResult Categories()
        {
            return View();
        }
        public IActionResult Brands()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
    }
}
