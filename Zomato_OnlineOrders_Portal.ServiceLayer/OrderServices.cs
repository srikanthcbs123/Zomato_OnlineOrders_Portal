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
    public class OrderServices:IOrderServices
    { 
        IOrderRepository _odses;
        public OrderServices(IOrderRepository odses)
        {
            _odses = odses;
        }

        public async Task<bool> AddOrders(OrderDto ordetail)
        {

            Order it = new Order();
            it.OrderID = ordetail.OrderID;
            it.PMethod = ordetail.PMethod;
            it.OrderNo = ordetail.OrderNo;
            it.CustomerID = ordetail.CustomerID;
            it.GTotal = ordetail.GTotal;
            it.DeletedOrderItemIDs = ordetail.DeletedOrderItemIDs;
            var res = await _odses.AddOrders(it);
            return res;
        }

        public async Task<bool> DeleteOrders(int id)
        {
            await _odses.DeleteOrders(id);
            return true;
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            List<OrderDto> lstordr = new List<OrderDto>();
            var res = await _odses.GetAllOrders();
            foreach (Order od in res)
            {
                OrderDto oddto = new OrderDto();
                oddto.OrderID = od.OrderID;
                oddto.PMethod = od.PMethod;
                oddto.OrderNo = od.OrderNo;
                oddto.id = od.id;
                oddto.CustomerID = od.CustomerID;
                oddto.GTotal = od.GTotal;
                oddto.DeletedOrderItemIDs = od.DeletedOrderItemIDs;
                lstordr.Add(oddto);

            }
            return lstordr;
        }

        public async Task<OrderDto> GetAllOrdersById(int id)
        {
            var res = await _odses.GetAllOrdersById(id);
            OrderDto oddto = new OrderDto();
            oddto.OrderID = res.OrderID;
            oddto.PMethod = res.PMethod;
            oddto.OrderNo = res.OrderNo;
            oddto.id = res.id;
            oddto.CustomerID = res.CustomerID;
            oddto.GTotal = res.GTotal;
            oddto.DeletedOrderItemIDs = res.DeletedOrderItemIDs;
            return oddto;

        }

        public async Task<bool> UpdateOrders(OrderDto ordetail)
        {
            Order it = new Order();
            it.id = ordetail.id;
            it.OrderID = ordetail.OrderID;
            it.PMethod = ordetail.PMethod;
            it.OrderNo = ordetail.OrderNo;
            it.CustomerID = ordetail.CustomerID;
            it.GTotal = ordetail.GTotal;
            it.DeletedOrderItemIDs = ordetail.DeletedOrderItemIDs;
            await _odses.UpdateOrders(it);
            return true;
        }
    }
}
