using System;
using System.Collections.Generic;
using Teste.API.Models;

namespace Teste.API.Service
{
    public interface ICustomerService
    {
        void Create(Customer customer);
        bool Update(Guid id, Customer customer);
        void Delete(Guid id);
        Customer GetById(Guid id);
        IList<Customer> GetAll();
    }
}
