using System;
using System.Collections.Generic;
using DomainModels.Models;

namespace AppService.AppService
{
    public interface ICustomerAppService
    {
        void Create(Customer customer);
        bool Update(Guid id, Customer customer);
        void Delete(Guid id);
        Customer GetById(Guid id);
        IList<Customer> GetAll();
    }
}
