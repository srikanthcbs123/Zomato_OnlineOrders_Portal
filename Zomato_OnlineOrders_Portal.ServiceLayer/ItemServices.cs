using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato_OnlineOrders_Portal.BussinessEntintes.DTOs;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Entities;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces;

namespace Zomato_OnlineOrders_Portal.ServiceLayer
{
    public class ItemServices:IItemServices
    {
        IItemRepository _itemRepository;
        public ItemServices(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<bool> AddItems(ItemDto itdetail)
        {
            Item it = new Item();
            it.Price = itdetail.Price;
            it.Name = itdetail.Name;
            it.ItemID = itdetail.ItemID;
            var res = await _itemRepository.AddItems(it);
            return res;
        }

        public async Task<bool> DeleteItems(int id)
        {
            await _itemRepository.DeleteItems(id);
            return true;
        }

        public async Task<ItemDto> GetAllItemById(int id)
        {
            var res = await _itemRepository.GetAllItemById(id);
            ItemDto it = new ItemDto();
            it.Price = res.Price;
            it.Name = res.Name;
            it.ItemID = res.ItemID;
            it.id = res.id;
            return it;
        }

        public async Task<List<ItemDto>> GetAllItems()
        {
            List<ItemDto> lstdto = new List<ItemDto>();
            var res = await _itemRepository.GetAllItems();
            foreach (Item it in res)
            {
                ItemDto itd = new ItemDto();
                itd.Price = it.Price;
                itd.Name = it.Name;
                itd.id = it.id;
                itd.ItemID = it.ItemID;
                lstdto.Add(itd);

            }
            return lstdto;

        }

        public async Task<bool> UpdateItems(ItemDto itdetail)
        {
            Item it = new Item();
            it.id = itdetail.id;
            it.Price = itdetail.Price;
            it.Name = itdetail.Name;
            it.ItemID = itdetail.ItemID;
            await _itemRepository.UpdateItems(it);
            return true;
        }
    }
}
