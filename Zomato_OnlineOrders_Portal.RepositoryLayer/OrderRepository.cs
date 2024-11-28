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
    public class OrderRepository:IOrderRepository
    {
        Zomato_OnlineOrdersContext _dbcontext;
        public OrderRepository(Zomato_OnlineOrdersContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> AddOrders(Order ordetail)
        {
            await _dbcontext.Orders.AddAsync(ordetail);
            _dbcontext.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteOrders(int id)
        {
            Order od = await _dbcontext.Orders.SingleOrDefaultAsync(e => e.id == e.id);
            if (od != null)
            {
                _dbcontext.Orders.Remove(od);
                _dbcontext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var res = await _dbcontext.Orders.ToListAsync();
            if (res.Count == 0)
            {
                return null;
            }
            else
            {
                return res;
            }
        }

        public async Task<Order> GetAllOrdersById(int id)
        {
            var res = await _dbcontext.Orders.Where(e => e.id == id).FirstOrDefaultAsync();
            if (res != null)
            {
                return res;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateOrders(Order ordetail)
        {
            _dbcontext.Orders.Update(ordetail);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
