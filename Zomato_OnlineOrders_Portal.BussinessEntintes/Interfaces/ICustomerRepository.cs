using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Entities;

namespace Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetAllCustomersById(int id);
        Task<bool> AddCustomers(Customer cmdetail);
        Task<bool> DeleteCustomers(int id);
        Task<bool> UpdateCustomers(Customer cmdetail);
    }
}
