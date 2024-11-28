using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Entities;
namespace Zomato_OnlineOrders_Portal.DBContext
{
    public class Zomato_OnlineOrdersContext:DbContext
    {
        public Zomato_OnlineOrdersContext(DbContextOptions<Zomato_OnlineOrdersContext> options)
                    : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> orderItems { get; set; }
    }
}
