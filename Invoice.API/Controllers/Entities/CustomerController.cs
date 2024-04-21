using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.API.Controllers.Entities{
    [ApiController]
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IMediator _mediator;
        private readonly ICustomerRepository _customerRepository;
        
        public CustomerController(ILogger<InvoiceController> logger, IMediator mediator, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _customerRepository = customerRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            return Ok(customers);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return Ok(customer);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            _customerRepository.Add(customer);
            _customerRepository.Save();
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            _customerRepository.Update(customer);
            _customerRepository.Save();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            _customerRepository.Delete(customer);
            _customerRepository.Save();
            return Ok();
        }
    }
}