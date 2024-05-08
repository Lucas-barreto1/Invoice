using Invoice.Core.Dtos;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.API.Controllers.Entities{
    [ApiController]
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            var customerDtos = MapToCustomerResponseDtoList(customers);
            return Ok(customerDtos);
        }
        
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProductsByCustomerId(Guid id)
        {
            var products = await _customerRepository.GetProductsByCustomerId(id);
            return Ok(products.ToList());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return NotFound();
            var customerDto = MapToCustomerResponseDto(customer);
            return Ok(customerDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerDto customerDTO)
        {
            var customer = MapToCustomer(customerDTO);
            _customerRepository.Add(customer);
            _customerRepository.Save();
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, MapToCustomerResponseDto(customer));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, CustomerDto customerDTO)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(id);
            if(existingCustomer == null)
                return NotFound();
            
            existingCustomer.Name = customerDTO.Name;
            existingCustomer.Email = customerDTO.Email;
            existingCustomer.Address = customerDTO.Address;
            
            _customerRepository.Update(existingCustomer);
            _customerRepository.Save();
            return Ok(MapToCustomerResponseDto(existingCustomer));
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return NotFound();
            _customerRepository.Delete(customer);
            _customerRepository.Save();
            return NoContent();
        }
        
        private CustomerResponseDto MapToCustomerResponseDto(Customer customer)
        {
            return new CustomerResponseDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Address = customer.Address
            };
        }
        
        private Customer MapToCustomer(CustomerDto customerDto)
        {
            return new Customer
            {
                Id = customerDto.Id,
                Name = customerDto.Name,
                Email = customerDto.Email,
                Address = customerDto.Address
            };
        }
        
        private List<CustomerResponseDto> MapToCustomerResponseDtoList(IEnumerable<Customer> customers)
        {
            return customers.Select(MapToCustomerResponseDto).ToList();
        }
        
    }
}