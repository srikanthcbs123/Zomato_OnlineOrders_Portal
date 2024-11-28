using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Entities;

namespace Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces
{
    public interface IOrderItemsRepository
    {
        Task<List<OrderItems>> GetAllOrderItems();
        Task<OrderItems> GetAllOrderItemsById(int id);
        Task<bool> AddOrderItems(OrderItems ordetail);
        Task<bool> DeleteOrderItems(int id);
        Task<bool> UpdateOrderItems(OrderItems ordetail);
    }
}
