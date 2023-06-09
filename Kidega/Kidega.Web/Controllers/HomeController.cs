using Kidega.Core.DTO;
using Kidega.Core.ServiceContracts;
using Kidega.Web.Extensions;
using Kidega.Web.Filters;
using Kidega.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace Kidega.Web.Controllers
{
    // Primary Constructor used for Dependency Injection
    public class HomeController(ILogger<HomeController> logger, IBookService bookService, IMemoryCache memoryCache) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllBooks() // TODO: Add caching
        {
            IEnumerable<BookResponse>? books = await memoryCache.GetOrCreateAsync("allBooks",async entry =>
            {
                entry.SetSlidingExpiration(TimeSpan.FromMinutes(5));
                logger.LogInformation("Books are cached at:{0}",DateTime.Now);
                return await bookService.GetAllBooksAsync();
            });
            return Json(new { data = books });
        }
        [ServiceFilter(typeof(ExceptionHandlingFilter))] 
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
        [ServiceFilter(typeof(ExceptionHandlingFilter))] 
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