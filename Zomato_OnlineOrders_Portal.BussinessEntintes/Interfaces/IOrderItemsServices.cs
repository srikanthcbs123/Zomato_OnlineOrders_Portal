using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato_OnlineOrders_Portal.BussinessEntintes.DTOs;

namespace Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces
{
    public interface IOrderItemsServices
    {
        Task<List<OrderItemDto>> GetAllOrderItems();
        Task<OrderItemDto> GetAllOrderItemsById(int id);
        Task<bool> AddOrderItems(OrderItemDto ordetail);
        Task<bool> DeleteOrderItems(int id);
        Task<bool> UpdateOrderItems(OrderItemDto ordetail);
    }
}
