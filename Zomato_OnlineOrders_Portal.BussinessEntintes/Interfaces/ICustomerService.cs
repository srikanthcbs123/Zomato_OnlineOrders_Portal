using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato_OnlineOrders_Portal.BussinessEntintes.DTOs;

namespace Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllCustomers();
        Task<CustomerDto> GetAllCustomersById(int id);
        Task<bool> AddCustomers(CustomerDto cmdetail);
        Task<bool> DeleteCustomers(int id);
        Task<bool> UpdateCustomers(CustomerDto cmdetail);
    }
}
