using Microsoft.AspNetCore.Mvc;

namespace licenseItExternal.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        public IActionResult Index()
        {
            return View();
        }
    }
}
