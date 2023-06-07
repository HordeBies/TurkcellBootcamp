using Microsoft.AspNetCore.Mvc;

namespace Kidega.Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
