using ArdonaghSoftwareChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArdonaghSoftwareChallenge.Services
{
    public class CustomerService
    {
        private static List<CustomerModel> customers = new List<CustomerModel>
    {
        new CustomerModel {Id=1, Name = "John Doe", Age = 30, PostCode = "SO12345", Height = 1.50 },
        new CustomerModel {Id=2, Name = "Jane Smith", Age = 25, PostCode = "BN56789", Height = 2.30 }
    };

        public List<CustomerModel> GetCustomers()
        {
            return customers;
        }

        public void AddEditCustomer(CustomerModel customer)
        {
            if (customer.Id == 0)
            {
                customer.Id = customers.Last().Id + 1;
                
                customers.Add(customer);
            }
            else
            {
                customers[customer.Id - 1] = customer;
            }
        }

        public CustomerModel GetCustomer(int index)
        {
            return customers[index];
        }
    }
}
