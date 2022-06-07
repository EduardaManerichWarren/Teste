using DomainModels.Models;
using System;
using System.Collections.Generic;

namespace DomainService.Service
{
    public class CustomerService : ICustomerService 
    {
        private readonly List<Customer> _customers = new();

        public void Create(Customer customer)
        {
            customer.Id = Guid.NewGuid();

            _customers.Add(customer);
        }

        public IList<Customer> GetAll()
        {
            return _customers;
        }

        public Customer GetById(Guid id)
        {
            return _customers.Find(x => x.Id == id); 
        }

        public bool Update(Guid id, Customer request)
        {
            request.Id = id;
            var index = _customers.FindIndex(x => x.Id == id);
            if (index == -1) return false;

            _customers[index] = request;
            return true;
        }

        public bool Delete(Guid id)
        {
            var customerId = GetById(id);
            if (customerId is not null)
            {
                _customers.Remove(customerId);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
