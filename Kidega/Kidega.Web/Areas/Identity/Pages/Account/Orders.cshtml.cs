using Kidega.Core.DTO;
using Kidega.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Kidega.Web.Areas.Identity.Pages.Account
{
    public class OrdersModel(IOrderService orderService) : PageModel
    {
        public IEnumerable<OrderResponse> OrdersViewModel { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            OrdersViewModel = (await orderService.GetAllOrdersAsync(id)).OrderByDescending(x => x.OrderDate);
            return Page();
        }
    }
}
