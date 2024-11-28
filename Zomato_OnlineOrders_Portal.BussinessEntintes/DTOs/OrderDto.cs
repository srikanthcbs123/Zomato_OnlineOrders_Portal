using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zomato_OnlineOrders_Portal.BussinessEntintes.DTOs
{
    public class OrderDto
    {
        public int id { get; set; }
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public int CustomerID { get; set; }
        public string PMethod { get; set; }
        public int GTotal { get; set; }
        public string DeletedOrderItemIDs { get; set; }
    }
}
