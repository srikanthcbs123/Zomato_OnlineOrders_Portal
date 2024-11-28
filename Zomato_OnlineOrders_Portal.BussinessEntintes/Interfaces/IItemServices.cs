using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato_OnlineOrders_Portal.BussinessEntintes.DTOs;

namespace Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces
{
    public interface IItemServices
    {
        Task<List<ItemDto>> GetAllItems();
        Task<ItemDto> GetAllItemById(int id);
        Task<bool> AddItems(ItemDto itdetail);
        Task<bool> DeleteItems(int id);
        Task<bool> UpdateItems(ItemDto itdetail);
    }
}
