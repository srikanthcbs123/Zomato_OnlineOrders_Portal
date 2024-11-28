using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato_OnlineOrders_Portal.BussinessEntintes.DTOs;

namespace Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces
{
    public interface IOrderServices
    {
        Task<List<OrderDto>> GetAllOrders();
        Task<OrderDto> GetAllOrdersById(int id);
        Task<bool> AddOrders(OrderDto ordetail);
        Task<bool> DeleteOrders(int id);
        Task<bool> UpdateOrders(OrderDto ordetail);
    }
}
