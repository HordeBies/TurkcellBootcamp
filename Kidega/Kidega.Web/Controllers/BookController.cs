using Microsoft.AspNetCore.Mvc;

namespace Kidega.Web.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
