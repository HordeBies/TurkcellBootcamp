using Microsoft.AspNetCore.Mvc;

namespace Kidega.Web.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
