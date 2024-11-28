using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zomato_OnlineOrders_Portal.BussinessEntintes.DTOs
{
    public class ItemDto
    {
        public int id { get; set; }
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
