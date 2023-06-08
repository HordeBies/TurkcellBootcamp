using Kidega.Core.DTO;
using Kidega.Core.ServiceContracts;
using Kidega.Web.Extensions;
using Kidega.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kidega.Web.Controllers
{
    // Primary Constructor used for Dependency Injection
    public class HomeController(ILogger<HomeController> logger, IBookService bookService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var model = await bookService.GetAllBooksAsync();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var model = await bookService.GetBookAsync(id.Value);
            return View(model);
        }
        [HttpPost] // Post from Details (Add to Cart button)
        public async Task<IActionResult> AddToCart(BookResponse model)
        {
            var cart = HttpContext.Session.GetJson<ShoppingCart>("cart") ?? new ShoppingCart();
            var item = new CartItem { Book = model, Quantity = 1 };
            cart.AddItem(item);
            HttpContext.Session.SetJson("cart", cart);
            TempData["success"] = "Item added to cart successfully";
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}