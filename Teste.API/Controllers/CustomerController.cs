using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{id:Guid}")]
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
            var customers = _service.GetAll();
            if (customers is null)
            {
                return NotFound();
            }
            return Ok(customers);
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

        [HttpDelete("{id:Guid}")]
        public ActionResult<Customer> Delete(Guid id)
        {
            _service.Delete(id);
            return Ok();
        }

        [HttpPut("{id:Guid}")]
        public ActionResult<Customer> Put(Guid id, Customer customer)
        {
            var sucessfullyUpdated = _service.Update(id, customer);

            return sucessfullyUpdated
                ? Ok(customer)
                : NotFound($"Customer not found for Id: {id}");
        }
    }
}
