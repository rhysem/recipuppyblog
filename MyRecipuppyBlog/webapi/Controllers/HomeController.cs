using Microsoft.AspNetCore.Mvc;

namespace RecipeAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
