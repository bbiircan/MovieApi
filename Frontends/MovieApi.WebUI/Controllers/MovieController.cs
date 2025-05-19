using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult MovieList()
        {
            ViewBag.v1 = "Movie List";
            ViewBag.v2 = "Home";
            ViewBag.v3 = "All Movies";
            return View();
        }
    }
}
