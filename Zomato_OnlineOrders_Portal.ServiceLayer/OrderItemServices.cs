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
    public class OrderItemServices:IOrderItemsServices
    {
        IOrderItemsRepository _orderItemsRepository;
        public OrderItemServices(IOrderItemsRepository orderItemsRepository)
        {
            this._orderItemsRepository = orderItemsRepository;
        }

        public async Task<bool> AddOrderItems(OrderItemDto ordetail)
        {
            OrderItems orditem = new OrderItems();
            orditem.OrderID = ordetail.OrderID;
            orditem.OrderItemID = ordetail.OrderItemID;
            orditem.Quantity = ordetail.Quantity;
            orditem.Price = ordetail.Price;
            orditem.ItemID = ordetail.ItemID;
            orditem.ItemName = ordetail.ItemName;
            orditem.Total = ordetail.Total;
            var res = await _orderItemsRepository.AddOrderItems(orditem);
            return res;
        }

        public async Task<bool> DeleteOrderItems(int id)
        {
            await _orderItemsRepository.DeleteOrderItems(id);
            return true;
        }

        public async Task<List<OrderItemDto>> GetAllOrderItems()
        {
            List<OrderItemDto> lstdto = new List<OrderItemDto>();
            var res = await _orderItemsRepository.GetAllOrderItems();
            foreach (OrderItems item in res)
            {
                OrderItemDto odtto = new OrderItemDto();
                odtto.OrderID = item.OrderID;
                odtto.OrderItemID = item.OrderItemID;
                odtto.Quantity = item.Quantity;
                odtto.Price = item.Price;
                odtto.id = item.id;
                odtto.ItemID = item.ItemID;
                odtto.ItemName = item.ItemName;
                odtto.Total = item.Total;
                lstdto.Add(odtto);
            }

            return lstdto;
        }

        public async Task<OrderItemDto> GetAllOrderItemsById(int id)
        {
            var res = await _orderItemsRepository.GetAllOrderItemsById(id);
            OrderItemDto odtto = new OrderItemDto();
            odtto.OrderID = res.OrderID;
            odtto.OrderItemID = res.OrderItemID;
            odtto.Quantity = res.Quantity;
            odtto.Price = res.Price;
            odtto.id = res.id;
            odtto.ItemID = res.ItemID;
            odtto.ItemName = res.ItemName;
            odtto.Total = res.Total;
            return odtto;

        }

        public async Task<bool> UpdateOrderItems(OrderItemDto ordetail)
        {
            OrderItems orditem = new OrderItems();
            orditem.id = ordetail.id;
            orditem.OrderID = ordetail.OrderID;
            orditem.OrderItemID = ordetail.OrderItemID;
            orditem.Quantity = ordetail.Quantity;
            orditem.Price = ordetail.Price;
            orditem.ItemID = ordetail.ItemID;
            orditem.ItemName = ordetail.ItemName;
            orditem.Total = ordetail.Total;
            await _orderItemsRepository.UpdateOrderItems(orditem);
            return true;
        }
    }
}
