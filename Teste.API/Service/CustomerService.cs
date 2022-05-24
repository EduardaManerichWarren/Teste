using Teste.API.Models;

namespace Teste.API.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customer = new List<Customer>(); 
      
        public void Create(Customer customer)
        {
            customer.Id = Guid.NewGuid();

            _customer.Add(customer);
        }

        public List<Customer> Get()
        {
            return _customer;
        }

        public Customer GetById(Guid id)
        {
            return _customer.Find(x => x.Id == id);             
        }

        public void Update(Customer customer)
        {
            _customer.Remove(GetById(customer.Id));
            _customer.Add(customer);
        }
        public void Delete(Guid id)
        {
            var customerId = GetById(id);
            _customer.Remove(customerId);
        }


    }
}
