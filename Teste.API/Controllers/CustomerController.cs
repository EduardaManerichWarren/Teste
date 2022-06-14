using DomainModels.Models;
using DomainService.Service;
using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {
                var customer = _service.GetById(id);
                if (customer is null)
                {
                    return NotFound();
                }
                return Ok(customer);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<Customer> Get()
        {
            try
            {
                var customers = _service.GetAll();
                if (customers is null)
                {
                    return NotFound();
                }
                return Ok(customers);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult Post(Customer customer)
        {
            try
            {
                if (customer is null)
                {
                    return BadRequest();
                }
                _service.Create(customer);
                return Ok(customer.Id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:Guid}")]
        public ActionResult<Customer> Delete(Guid id)
        {
            
            try
            {
                return _service.Delete(id)
                    ? return Ok();
                    : BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:Guid}")]
        public ActionResult<Customer> Put(Guid id, Customer customer)
        {
            var sucessfullyUpdated = _service.Update(id, customer);

            try
            {
                return sucessfullyUpdated
                    ? Ok(customer)
                    : NotFound($"Customer not found for Id: {id}");

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
