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
    public class CustomerServices:ICustomerService
    {
        ICustomerRepository _customerRepository;
        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> AddCustomers(CustomerDto cmdetail)
        {
            Customer cm = new Customer();
            cm.CustomerID = cmdetail.CustomerID;
            cm.Name = cmdetail.Name;
            var res = await _customerRepository.AddCustomers(cm);
            return res;
        }

        public async Task<bool> DeleteCustomers(int id)
        {
            await _customerRepository.DeleteCustomers(id);
            return true;
        }

        public async Task<List<CustomerDto>> GetAllCustomers()
        {
            List<CustomerDto> cstdto = new List<CustomerDto>();
            var res = await _customerRepository.GetAllCustomers();
            foreach (Customer cm in res)
            {
                CustomerDto cmdto = new CustomerDto();
                cmdto.CustomerID = cm.CustomerID;
                cmdto.Name = cm.Name;
                cmdto.id = cm.id;
                cstdto.Add(cmdto);

            }
            return cstdto;
        }

        public async Task<CustomerDto> GetAllCustomersById(int id)
        {
            var res = await _customerRepository.GetAllCustomersById(id);
            CustomerDto cmdto = new CustomerDto();
            cmdto.id = res.id;
            cmdto.Name = res.Name;
            cmdto.CustomerID = res.CustomerID;
            return cmdto;
        }

        public async Task<bool> UpdateCustomers(CustomerDto cmdetail)
        {
            Customer cm = new Customer();
            cm.id = cmdetail.id;
            cm.Name = cmdetail.Name;
            cm.CustomerID = cmdetail.CustomerID;
            await _customerRepository.UpdateCustomers(cm);
            return true;
        }
    }
}
