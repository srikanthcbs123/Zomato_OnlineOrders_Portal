using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zomato_OnlineOrders_Portal.BussinessEntintes.Entities
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public int CustomerID { get; set; }
        public string PMethod { get; set; }
        public int GTotal { get; set; }

        public string DeletedOrderItemIDs { get; set; }
    }
}
