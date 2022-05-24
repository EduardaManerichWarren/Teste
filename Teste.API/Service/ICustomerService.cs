using Teste.API.Models;

namespace Teste.API.Service
{
    public interface ICustomerService
    {
        void Create(Customer customer);
        void Update(Customer customer);    
        void Delete(Guid id);
        Customer GetById(Guid id);
        List<Customer> Get();
    }
}
