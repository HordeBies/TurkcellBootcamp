using Kidega.Core.DTO;
using Kidega.Core.ServiceContracts;
using Kidega.Web.Extensions;
using Kidega.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kidega.Web.Controllers
{
    public class CartController(IBookService bookService, IOrderService orderService) : Controller
    {
        private ShoppingCartVM viewModel { get; set; }
        private async Task PopulateViewModel()
        {
            var cart = HttpContext.Session.GetJson<ShoppingCart>("cart") ?? new ShoppingCart();
            var shipment = HttpContext.Session.GetJson<ShipmentInformation>("shipment") ?? new ShipmentInformation();
            foreach (var item in cart.CartItems)
            {
                item.Book = await bookService.GetBookAsync(item.Book.Id);
            }
            viewModel = new ShoppingCartVM
            {
                ShoppingCart = cart,
                ShipmentInformation = shipment
            };
        }
        public async Task<IActionResult> Index()
        {
            await PopulateViewModel();
            return View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Summary()
        {
            await PopulateViewModel();
            if(viewModel.ShoppingCart.CartItems.Count == 0)
            {
                TempData["error"] = "Your cart is empty";
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ActionName("Summary")]
        public async Task<IActionResult> PlaceOrder(ShoppingCartVM request)
        {
            HttpContext.Session.SetJson("shipment", request.ShipmentInformation);
            await PopulateViewModel();
            var addRequest = new OrderAddRequest
            {
                FullName = viewModel.ShipmentInformation.FullName,
                IdentityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                OrderDate = DateTime.Now,
                OrderItems = viewModel.ShoppingCart.CartItems.Select(x => new OrderItemAddRequest
                {
                    BookId = x.Book.Id,
                    Quantity = x.Quantity,
                }),
                PhoneNumber = viewModel.ShipmentInformation.PhoneNumber,
                PostalCode = viewModel.ShipmentInformation.PostalCode,
                Address = viewModel.ShipmentInformation.Address,
                City = viewModel.ShipmentInformation.City,
            };
            await orderService.CreateOrderAsync(addRequest);
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Remove(int itemId)
        {
            var cart = HttpContext.Session.GetJson<ShoppingCart>("cart") ?? new ShoppingCart();
            var item = cart.CartItems.FirstOrDefault(x => x.Book.Id == itemId);
            if (item != null)
            {
                cart.CartItems.Remove(item);
                HttpContext.Session.SetJson("cart", cart);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Plus(int itemId)
        {
            var cart = HttpContext.Session.GetJson<ShoppingCart>("cart") ?? new ShoppingCart();
            var item = cart.CartItems.FirstOrDefault(x => x.Book.Id == itemId);
            if (item != null)
            {
                item.Quantity++;
            }
            HttpContext.Session.SetJson("cart", cart);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Minus(int itemId)
        {
            var cart = HttpContext.Session.GetJson<ShoppingCart>("cart") ?? new ShoppingCart();
            var item = cart.CartItems.FirstOrDefault(x => x.Book.Id == itemId);
            if (item != null)
            {
                item.Quantity--;
                if (item.Quantity <= 0)
                {
                    cart.CartItems.Remove(item);
                }
            }
            HttpContext.Session.SetJson("cart", cart);
            return RedirectToAction(nameof(Index));
        }
    }
}
