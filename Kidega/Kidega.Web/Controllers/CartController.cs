using Kidega.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kidega.Web.Controllers
{
    public class CartController : Controller
    {

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
