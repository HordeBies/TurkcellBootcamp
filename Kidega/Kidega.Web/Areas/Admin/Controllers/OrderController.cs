using AutoMapper;
using Kidega.Core.DTO;
using Kidega.Core.ServiceContracts;
using Kidega.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kidega.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController(IOrderService orderService, IMapper mapper) : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            var order = await orderService.GetOrderAsync(id.Value);
            var model = mapper.Map<OrderUpdateRequest>(order);
            ViewBag.Summary = order.OrderItems;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(OrderUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                await orderService.UpdateOrderAsync(request);
                TempData["success"] = "Order updated successfully";
                return RedirectToAction(nameof(Index));
            }
            var order = await orderService.GetOrderAsync(request.Id);
            ViewBag.Summary = order.OrderItems;
            return View(request);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            await orderService.DeleteOrderAsync(id.Value);
            return Json(new { success = true, message = "Delete Successful" });
        }

        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await orderService.GetAllOrdersAsync(null) });
        }
    }
}
