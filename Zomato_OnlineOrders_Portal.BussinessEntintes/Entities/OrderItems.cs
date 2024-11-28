using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zomato_OnlineOrders_Portal.BussinessEntintes.Entities
{
    public class OrderItems
    {
        [Key]
        public int id { get; set; }
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
