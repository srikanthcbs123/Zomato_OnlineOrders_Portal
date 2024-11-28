using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Entities;

namespace Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllItems();
        Task<Item> GetAllItemById(int id);
        Task<bool> AddItems(Item itdetail);
        Task<bool> DeleteItems(int id);
        Task<bool> UpdateItems(Item itdetail);
    }
}
