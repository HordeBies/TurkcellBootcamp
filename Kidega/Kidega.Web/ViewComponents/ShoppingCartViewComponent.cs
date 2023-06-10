using Kidega.Web.Extensions;
using Kidega.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kidega.Web.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = HttpContext.Session.GetJson<ShoppingCart>("cart");
            return View(cart == null ? 0 : cart.TotalItemCount());

            // TODO: Can save the shopping cart in database and retrieve it from there instead of session storage and use session to store the number of items in cart and clear or set it when user logs out or logs in.
        }
    }
}
