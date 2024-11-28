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
    public class OrderItemsRepository:IOrderItemsRepository
    {
        Zomato_OnlineOrdersContext _rstdbcnxt;
        public OrderItemsRepository(Zomato_OnlineOrdersContext rstdbcnxt)
        {
            _rstdbcnxt = rstdbcnxt;
        }

        public async Task<bool> AddOrderItems(OrderItems ordetail)
        {
            await _rstdbcnxt.orderItems.AddAsync(ordetail);
            _rstdbcnxt.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteOrderItems(int id)
        {
            var remove = await _rstdbcnxt.orderItems.Where(e => e.id == e.id).FirstOrDefaultAsync();
            if (remove != null)
            {
                _rstdbcnxt.orderItems.Remove(remove);
                _rstdbcnxt.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<OrderItems>> GetAllOrderItems()
        {
            var res = await _rstdbcnxt.orderItems.ToListAsync();
            if (res.Count == 0)
            {
                return null;
            }
            else
            {
                return res;
            }
        }

        public async Task<OrderItems> GetAllOrderItemsById(int id)
        {
            var res = await _rstdbcnxt.orderItems.Where(e => e.id == e.id).FirstOrDefaultAsync();
            if (res == null)
            {
                return null;
            }
            else
            {
                return res;
            }
        }

        public async Task<bool> UpdateOrderItems(OrderItems ordetail)
        {
            _rstdbcnxt.orderItems.Update(ordetail);
            await _rstdbcnxt.SaveChangesAsync();
            return true;
        }
    }
}
