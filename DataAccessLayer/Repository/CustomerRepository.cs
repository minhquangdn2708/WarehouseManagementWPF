using BusinessObject;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetAllCustomers()
        {
            return CustomerDAO.Instance.GetAll();
        }

        public Customer GetCustomerById(int CustomerId)
        {
            return CustomerDAO.Instance.GetById(CustomerId);
        }

        public void AddCustomer(Customer Customer)
        {
            CustomerDAO.Instance.Add(Customer);
        }

        public void UpdateCustomer(Customer Customer)
        {
            CustomerDAO.Instance.Update(Customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            CustomerDAO.Instance.Delete(customer);
        }
    }
}
