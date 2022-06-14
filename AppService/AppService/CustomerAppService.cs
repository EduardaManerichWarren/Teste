using DomainModels.Models;
using System;
using System.Collections.Generic;

namespace AppService.AppService
{
    public class CustomerAppService : ICustomerAppService
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

        public void Delete(Guid id)
        {
            var customerId = GetById(id);
            _customers.Remove(customerId);
        }
    }
}
