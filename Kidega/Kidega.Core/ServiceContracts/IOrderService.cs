using Kidega.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kidega.Core.ServiceContracts
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponse>> GetAllOrdersAsync(string? userId);
        Task<OrderResponse> GetOrderAsync(int id);
        Task<OrderResponse> CreateOrderAsync(OrderAddRequest request);
        Task UpdateOrderAsync(OrderUpdateRequest request);
        Task DeleteOrderAsync(int id);
    }
}
