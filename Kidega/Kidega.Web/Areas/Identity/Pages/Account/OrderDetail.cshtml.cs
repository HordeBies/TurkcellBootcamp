using Kidega.Core.DTO;
using Kidega.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kidega.Web.Areas.Identity.Pages.Account
{
    public class OrderDetailModel(IOrderService orderService, IBookService bookService) : PageModel
    {
        public OrderResponse OrderViewModel { get; set; }
        public Dictionary<OrderItemResponse, BookResponse> OrderItemBookDetails { get; set; } = new();
        public async Task<IActionResult> OnGet(int? id)
        {
            if(id == null)
                return RedirectToPage("/Account/Orders");
            OrderViewModel = await orderService.GetOrderAsync(id.Value);
            foreach (var item in OrderViewModel.OrderItems)
            {
                OrderItemBookDetails[item] = await bookService.GetBookAsync(item.BookId);
            }
            return Page();
        }
    }
}
