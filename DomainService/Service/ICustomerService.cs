using System;
using System.Collections.Generic;
using DomainModels.Models;

namespace DomainService.Service
{
    public interface ICustomerService
    {
        void Create(Customer customer);
        bool Update(Guid id, Customer customer);
        bool Delete(Guid id);
        Customer GetById(Guid id);
        IList<Customer> GetAll();
    }
}
