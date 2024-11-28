using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zomato_OnlineOrders_Portal.BussinessEntintes.Entities
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        public int CustomerID { get; set; }
        public string Name { get; set; }
    }
}
