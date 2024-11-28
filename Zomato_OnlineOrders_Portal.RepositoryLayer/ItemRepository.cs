using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Entities;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces;
using Zomato_OnlineOrders_Portal.DBContext;

namespace Zomato_OnlineOrders_Portal.RepositoryLayer
{
    public class ItemRepository : IItemRepository
    {
        public Zomato_OnlineOrdersContext _rstdbcontext;
        public ItemRepository(Zomato_OnlineOrdersContext rstdbcontext)
        {
            _rstdbcontext = rstdbcontext;
        }
        public async Task<bool> AddItems(Item itdetail)
        {
            await _rstdbcontext.Items.AddAsync(itdetail);
            _rstdbcontext.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteItems(int id)
        {
            var remove = await _rstdbcontext.Items.Where(e => e.id == e.id).FirstOrDefaultAsync();
            if (remove != null)
            {
                _rstdbcontext.Items.Remove(remove);
                _rstdbcontext.SaveChanges();
                return true;
            }
            return false;
           

        }

        public async Task<Item> GetAllItemById(int id)
        {
            var it = await _rstdbcontext.Items.Where(e => e.id == id).FirstOrDefaultAsync();
            if (it == null)
            {
                return null;
            }
            else
            {
                return it;
            }
        }

        public async Task<List<Item>> GetAllItems()
        {
            var it = await _rstdbcontext.Items.ToListAsync();
            if (it.Count == 0)
            {
                return null;
            }
            else
            {
                return it;
            }
        }

        public async Task<bool> UpdateItems(Item itdetail)
        {
            _rstdbcontext.Items.Update(itdetail);
            await _rstdbcontext.SaveChangesAsync();
            return true;
        }
    }
}
