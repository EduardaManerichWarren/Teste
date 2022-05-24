using Microsoft.AspNetCore.Mvc;
using Teste.API.Models;
using Teste.API.Service;

namespace Teste.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet ("ById")]
        public ActionResult<Customer> Get(Guid id) 
        { 
            var customer = _service.GetById(id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet]
        public ActionResult<Customer> Get() 
        {
            var customer = _service.Get();
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public ActionResult Post(Customer customer)
        {
            if (customer is null)
            {
                return BadRequest();
            }
            _service.Create(customer);
            return Ok(customer);
        }

        [HttpDelete]
        public ActionResult<Customer> Delete(Guid id) 
        {
            _service.Delete(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult<Customer> Put(Customer customer) 
        {
            _service.Update(customer);
            return Ok(customer);
        }
    }
}
