using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebResumeApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Resume()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
