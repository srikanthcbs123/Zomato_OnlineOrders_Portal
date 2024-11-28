using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Entities;
using Zomato_OnlineOrders_Portal.BussinessEntintes.Interfaces;
using Zomato_OnlineOrders_Portal.DBContext;

namespace Zomato_OnlineOrders_Portal.RepositoryLayer
{
    public class CustomerRepository:ICustomerRepository
    {
        public Zomato_OnlineOrdersContext _restcon;
        public CustomerRepository(Zomato_OnlineOrdersContext restcon)
        {
            this._restcon = restcon;
        }
        public async Task<bool> AddCustomers(Customer cmdetail)
        {
            await _restcon.Customers.AddAsync(cmdetail);
            _restcon.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteCustomers(int id)
        {
            Customer cm = _restcon.Customers.SingleOrDefault(e => e.id == id);
            if (cm != null)
            {
                _restcon.Customers.Remove(cm);
                _restcon.SaveChanges();
                return true;
            }
            else return false;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var rm = _restcon.Customers.ToList();
            if (rm.Count == 0)
                return null;
            else return rm;
        }

        public async Task<Customer> GetAllCustomersById(int id)
        {
            var rm = await _restcon.Customers.Where(e => e.id == id).FirstOrDefaultAsync();

            if (rm == null)
                return null;
            else
                return rm;
        }

        public async Task<bool> UpdateCustomers(Customer cmdetail)
        {
            _restcon.Customers.Update(cmdetail);
            await _restcon.SaveChangesAsync();
            return true;
        }
    }
}
