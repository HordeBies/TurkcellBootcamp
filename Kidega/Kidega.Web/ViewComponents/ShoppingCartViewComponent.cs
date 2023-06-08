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

            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //if(claim == null)
            //{
            //    HttpContext.Session.Clear();
            //    return View(0);
            //}
            //else
            //{
            //    if(HttpContext.Session.GetInt32(SessionSD.ShoppingCart) == null)
            //        HttpContext.Session.SetInt32(SessionSD.ShoppingCart, (await unitOfWork.ShoppingCart.GetAll(r => r.ApplicationUserId == claim.Value)).Count());
                
            //    return View(HttpContext.Session.GetInt32(SessionSD.ShoppingCart));
            //}
        }
    }
}
