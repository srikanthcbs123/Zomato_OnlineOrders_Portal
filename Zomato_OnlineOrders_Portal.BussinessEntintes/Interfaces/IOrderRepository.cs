using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Entities;

namespace Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetAllOrdersById(int id);
        Task<bool> AddOrders(Order ordetail);
        Task<bool> DeleteOrders(int id);
        Task<bool> UpdateOrders(Order ordetail);
    }
}
