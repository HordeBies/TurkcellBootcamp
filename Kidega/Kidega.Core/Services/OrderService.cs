using AutoMapper;
using Kidega.Core.DTO;
using Kidega.Core.ServiceContracts;
using Kidega.Domain.Entities;
using Kidega.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kidega.Core.Services
{
    public class OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IBookRepository bookRepository, IMapper mapper) : IOrderService
    {
        public async Task<OrderResponse> CreateOrderAsync(OrderAddRequest request)
        {
            var order = mapper.Map<Order>(request);
            await orderRepository.Add(order);
            decimal total = 0;
            foreach (var item in request.OrderItems)
            {
                var book = await bookRepository.Get(item.BookId);
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    BookId = item.BookId,
                    Quantity = item.Quantity,
                    UnitPriceOnPurchase = item.Quantity * book!.Price,                    
                };
                total += orderItem.UnitPriceOnPurchase;
                await orderItemRepository.Add(orderItem);
            }
            order.OrderTotal = total;
            await orderRepository.Update(order);

            var response = mapper.Map<OrderResponse>(order);
//            var orderItems = (await orderItemRepository.GetAll("Book")).Where(r => r.OrderId == order.Id);
//            response.OrderItems = mapper.Map<IEnumerable<OrderItemResponse>>(orderItems);
            return response;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await orderRepository.Get(id,"OrderItems");
            if(order == null)
            {
                throw new Exception("Order not found");
            }
            foreach (var item in order.OrderItems)
            {
                await orderItemRepository.Remove(item);
            }
            await orderRepository.Remove(order);
        }

        public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync(string? userId)
        {
            var orders = await orderRepository.GetAll();
            if(userId != null) orders = orders.Where(r => r.IdentityUserId == userId);
            return mapper.Map<IEnumerable<OrderResponse>>(orders);
        }

        public async Task<OrderResponse> GetOrderAsync(int id)
        {
            var order = await orderRepository.Get(id,"OrderItems");
            if(order == null)
            {
                throw new Exception("Order not found");
            }
            return mapper.Map<OrderResponse>(order);
        }

        public async Task UpdateOrderAsync(OrderUpdateRequest request)
        {
            var order = await orderRepository.Get(request.Id);
            if(order == null)
            {
                throw new Exception("Order not found");
            }
            order.FullName = request.FullName;
            order.PhoneNumber = request.PhoneNumber;
            order.Address = request.Address;
            order.City = request.City;
            order.PostalCode = request.PostalCode;
            await orderRepository.Update(order);
        }
    }
}
